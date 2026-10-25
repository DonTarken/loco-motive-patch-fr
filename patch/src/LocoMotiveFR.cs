using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using TMPro;

namespace LocoMotiveFR
{
    [BepInPlugin("org.dontarken.locomotive.fr", "Loco Motive Patch FR", "1.2.0")]
    public class LocoMotiveFRPlugin : BaseUnityPlugin
    {
        public static LocoMotiveFRPlugin Instance;
        public static BepInEx.Logging.ManualLogSource Log;
        public static Dictionary<string, string> TextByEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public static string TranslationDir;

        void Awake()
        {
            Instance = this;
            Log = Logger;
            TranslationDir = Path.Combine(Paths.PluginPath, "LocoMotiveFR_Data");
            if (!Directory.Exists(TranslationDir))
            {
                TranslationDir = Path.Combine(Paths.GameRootPath, "Translations_FR");
            }

            Logger.LogInfo("=== [Loco Motive FR] Initialisation du patch v1.2.0... ===");
            LoadTranslations();

            var harmony = new Harmony("org.dontarken.locomotive.fr");

            // Application manuelle et isolée de chaque patch pour une robustesse maximale
            PatchMethod(harmony, typeof(PowerTools.Quest.SystemText), "GetDisplayText", 
                new Type[] { typeof(string), typeof(int), typeof(string), typeof(bool) },
                typeof(Patch_SystemText_GetDisplayText), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.Quest.SystemText), "Localize", 
                new Type[] { typeof(string), typeof(int), typeof(string) },
                typeof(Patch_SystemText_Localize), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.Quest.SystemText), "LocalizeWithID", 
                new Type[] { typeof(string), typeof(int), typeof(string) },
                typeof(Patch_SystemText_LocalizeWithID), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.Quest.SystemText), "Awake", 
                Type.EmptyTypes,
                typeof(Patch_SystemText_Awake), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.QuestTextPro), "SetText", 
                new Type[] { typeof(string) },
                typeof(Patch_QuestTextPro_SetText), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.QuestGui.LabelPro), "set_Text", 
                new Type[] { typeof(string) },
                typeof(Patch_LabelPro_set_Text), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.QuestGui.Label), "set_Text", 
                new Type[] { typeof(string) },
                typeof(Patch_Label_set_Text), "Prefix", null);

            PatchMethod(harmony, typeof(TMP_Text), "set_text", 
                new Type[] { typeof(string) },
                typeof(Patch_TMP_Text_set_text), "Prefix", null);

            PatchMethod(harmony, typeof(TMP_Text), "SetText", 
                new Type[] { typeof(string), typeof(bool) },
                typeof(Patch_TMP_Text_SetText), "Prefix", null);

            PatchMethod(harmony, typeof(PowerTools.Quest.DialogOption), "get_Text", 
                Type.EmptyTypes,
                typeof(Patch_DialogOption_get_Text), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.DialogOption), "get_Description", 
                Type.EmptyTypes,
                typeof(Patch_DialogOption_get_Description), null, "Postfix");

            Logger.LogInfo(string.Format("=== [Loco Motive FR] Patch actif ! {0} entrées de texte chargées. ===", TextByEnglish.Count));
        }

        private static void PatchMethod(Harmony harmony, Type targetType, string methodName, Type[] parameters, Type patchType, string prefixName, string postfixName)
        {
            try
            {
                var target = parameters != null && parameters.Length > 0 
                    ? AccessTools.Method(targetType, methodName, parameters) 
                    : AccessTools.Method(targetType, methodName);

                if (target == null)
                {
                    if (Log != null) Log.LogWarning(string.Format("Méthode introuvable pour patch : {0}.{1}", targetType.Name, methodName));
                    return;
                }

                HarmonyMethod prefix = prefixName != null ? new HarmonyMethod(patchType, prefixName) : null;
                HarmonyMethod postfix = postfixName != null ? new HarmonyMethod(patchType, postfixName) : null;

                harmony.Patch(target, prefix, postfix);
                if (Log != null) Log.LogInfo(string.Format("-> Patch Harmony appliqué sur : {0}.{1}", targetType.Name, methodName));
            }
            catch (Exception ex)
            {
                if (Log != null) Log.LogError(string.Format("Erreur lors du patch de {0}.{1} : {2}", targetType.Name, methodName, ex.Message));
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Logger.LogInfo("[Loco Motive FR] Rechargement à chaud des traductions (touche F5)...");
                LoadTranslations();
            }
        }

        public static void LoadTranslations()
        {
            TextByEnglish.Clear();

            if (!Directory.Exists(TranslationDir))
            {
                Directory.CreateDirectory(TranslationDir);
            }

            string[] tsvFiles = Directory.GetFiles(TranslationDir, "*.tsv", SearchOption.AllDirectories);
            foreach (var file in tsvFiles)
            {
                try
                {
                    LoadTsvFile(file);
                }
                catch (Exception ex)
                {
                    if (Log != null)
                        Log.LogError("Erreur lecture " + file + " : " + ex.Message);
                }
            }

            if (Log != null)
            {
                Log.LogInfo(string.Format("Chargement terminé : {0} textes chargés en mémoire.", TextByEnglish.Count));
            }
        }

        private static void LoadTsvFile(string path)
        {
            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                bool isFirst = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isFirst && (line.StartsWith("Id\t") || line.StartsWith("Character\t"))) { isFirst = false; continue; }
                    isFirst = false;

                    string[] parts = line.Split('\t');
                    if (parts.Length >= 4)
                    {
                        string character = parts[1].Trim();
                        string en = parts[2].Trim().Replace(" \\n ", "\n");
                        string fr = parts[3].Trim().Replace(" \\n ", "\n");

                        if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr))
                        {
                            TextByEnglish[en] = fr;
                            if (!string.IsNullOrEmpty(character))
                            {
                                TextByEnglish[character + "::" + en] = fr;
                            }
                        }
                    }
                    else if (parts.Length >= 2)
                    {
                        string en = parts[0].Trim().Replace(" \\n ", "\n");
                        string fr = parts[1].Trim().Replace(" \\n ", "\n");
                        if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr))
                        {
                            TextByEnglish[en] = fr;
                        }
                    }
                }
            }
        }

        public static string TranslateString(string input, string character = null)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string fr;
            string trimmed = input.Trim();

            // 1. Recherche par (Personnage::Texte)
            if (!string.IsNullOrEmpty(character))
            {
                string charKey = character + "::" + trimmed;
                if (TextByEnglish.TryGetValue(charKey, out fr) && !string.IsNullOrEmpty(fr))
                {
                    return PreserveSpaces(input, fr);
                }
            }

            // 2. Recherche par texte direct
            if (TextByEnglish.TryGetValue(input, out fr) && !string.IsNullOrEmpty(fr))
            {
                return fr;
            }

            // 3. Recherche par texte rogné
            if (TextByEnglish.TryGetValue(trimmed, out fr) && !string.IsNullOrEmpty(fr))
            {
                return PreserveSpaces(input, fr);
            }

            return input;
        }

        private static string PreserveSpaces(string original, string translated)
        {
            int startSpaces = original.Length - original.TrimStart().Length;
            int endSpaces = original.Length - original.TrimEnd().Length;
            if (startSpaces == 0 && endSpaces == 0) return translated;
            return original.Substring(0, startSpaces) + translated + original.Substring(original.Length - endSpaces);
        }
    }

    public static class Patch_SystemText_GetDisplayText
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName, bool isPlayer)
        {
            if (string.IsNullOrEmpty(defaultText)) return true;

            string fr = LocoMotiveFRPlugin.TranslateString(defaultText, characterName);
            if (fr != defaultText)
            {
                __result = fr;
                return false;
            }
            return true;
        }
    }

    public static class Patch_SystemText_Localize
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            if (string.IsNullOrEmpty(defaultText)) return true;

            string fr = LocoMotiveFRPlugin.TranslateString(defaultText, characterName);
            if (fr != defaultText)
            {
                __result = fr;
                return false;
            }
            return true;
        }
    }

    public static class Patch_SystemText_LocalizeWithID
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            if (string.IsNullOrEmpty(defaultText)) return true;

            string fr = LocoMotiveFRPlugin.TranslateString(defaultText, characterName);
            if (fr != defaultText)
            {
                __result = fr;
                return false;
            }
            return true;
        }
    }

    public static class Patch_SystemText_Awake
    {
        public static void Postfix(PowerTools.Quest.SystemText __instance)
        {
            try
            {
                var fi = AccessTools.Field(typeof(PowerTools.Quest.SystemText), "m_languages");
                if (fi != null)
                {
                    var currentLangs = (PowerTools.Quest.LanguageData[])fi.GetValue(__instance);
                    var newLangs = new List<PowerTools.Quest.LanguageData>();
                    if (currentLangs != null)
                    {
                        newLangs.AddRange(currentLangs);
                    }
                    bool hasFr = false;
                    int frIndex = -1;
                    for (int i = 0; i < newLangs.Count; i++)
                    {
                        var l = newLangs[i];
                        if (l != null && (l.m_code == "fr" || l.m_description == "Français"))
                        {
                            hasFr = true;
                            frIndex = i;
                            break;
                        }
                    }
                    if (!hasFr)
                    {
                        var frLang = new PowerTools.Quest.LanguageData();
                        frLang.m_code = "fr";
                        frLang.m_description = "Français";
                        newLangs.Add(frLang);
                        frIndex = newLangs.Count - 1;
                        fi.SetValue(__instance, newLangs.ToArray());
                        if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogInfo("-> Langue 'Français' ajoutée avec succès au menu des langues de SystemText !");
                    }

                    // Activer le Français par défaut si la langue était sur 0 (English)
                    try
                    {
                        var pq = PowerTools.Quest.PowerQuest.Get;
                        if (pq != null && pq.Settings != null && frIndex > 0)
                        {
                            if (pq.Settings.LanguageId == 0)
                            {
                                pq.Settings.LanguageId = frIndex;
                                if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogInfo(string.Format("-> Langue active définie sur Français (index {0}) !", frIndex));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogWarning("Impossible de forcer la langue active : " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogError("Erreur lors de l'ajout du Français dans SystemText.m_languages : " + ex.Message);
            }
        }
    }

    public static class Patch_QuestTextPro_SetText
    {
        public static void Prefix(ref string text)
        {
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    public static class Patch_LabelPro_set_Text
    {
        public static void Prefix(ref string value)
        {
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_Label_set_Text
    {
        public static void Prefix(ref string value)
        {
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_TMP_Text_set_text
    {
        public static void Prefix(ref string value)
        {
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_TMP_Text_SetText
    {
        public static void Prefix(ref string sourceText)
        {
            sourceText = LocoMotiveFRPlugin.TranslateString(sourceText);
        }
    }

    public static class Patch_DialogOption_get_Text
    {
        public static void Postfix(ref string __result)
        {
            if (!string.IsNullOrEmpty(__result))
            {
                __result = LocoMotiveFRPlugin.TranslateString(__result);
            }
        }
    }

    public static class Patch_DialogOption_get_Description
    {
        public static void Postfix(ref string __result)
        {
            if (!string.IsNullOrEmpty(__result))
            {
                __result = LocoMotiveFRPlugin.TranslateString(__result);
            }
        }
    }
}
