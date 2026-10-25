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
    [BepInPlugin("org.dontarken.locomotive.fr", "Loco Motive Patch FR", "1.1.0")]
    public class LocoMotiveFRPlugin : BaseUnityPlugin
    {
        public static LocoMotiveFRPlugin Instance;
        public static BepInEx.Logging.ManualLogSource Log;
        public static Dictionary<int, string> DialoguesById = new Dictionary<int, string>();
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

            Logger.LogInfo("=== [Loco Motive FR] Initialisation du patch v1.1.0... ===");
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

            Logger.LogInfo(string.Format("=== [Loco Motive FR] Patch actif ! {0} répliques (ID) et {1} entrées de texte chargées. ===", DialoguesById.Count, TextByEnglish.Count));
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
            DialoguesById.Clear();
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
                Log.LogInfo(string.Format("Chargement terminé : {0} répliques par ID, {1} textes par chaîne.", DialoguesById.Count, TextByEnglish.Count));
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
                    if (isFirst && line.StartsWith("Id\t")) { isFirst = false; continue; }
                    isFirst = false;

                    string[] parts = line.Split('\t');
                    if (parts.Length >= 4)
                    {
                        int id;
                        int.TryParse(parts[0].Trim(), out id);
                        string en = parts[2].Trim().Replace(" \\n ", "\n");
                        string fr = parts[3].Trim().Replace(" \\n ", "\n");

                        if (!string.IsNullOrEmpty(fr))
                        {
                            if (id > 0)
                            {
                                DialoguesById[id] = fr;
                            }
                            if (!string.IsNullOrEmpty(en))
                            {
                                TextByEnglish[en] = fr;
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

        public static string TranslateString(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string fr;
            // 1. Recherche directe (insensible à la casse)
            if (TextByEnglish.TryGetValue(input, out fr) && !string.IsNullOrEmpty(fr))
            {
                return fr;
            }

            // 2. Recherche avec rognage des espaces
            string trimmed = input.Trim();
            if (TextByEnglish.TryGetValue(trimmed, out fr) && !string.IsNullOrEmpty(fr))
            {
                if (input != trimmed)
                {
                    int startSpaces = input.Length - input.TrimStart().Length;
                    int endSpaces = input.Length - input.TrimEnd().Length;
                    return input.Substring(0, startSpaces) + fr + input.Substring(input.Length - endSpaces);
                }
                return fr;
            }

            return input;
        }
    }

    public static class Patch_SystemText_GetDisplayText
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName, bool isPlayer)
        {
            string fr;
            if (id > 0 && LocoMotiveFRPlugin.DialoguesById.TryGetValue(id, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            if (!string.IsNullOrEmpty(defaultText))
            {
                string trans = LocoMotiveFRPlugin.TranslateString(defaultText);
                if (trans != defaultText)
                {
                    __result = trans;
                    return false;
                }
            }
            return true;
        }
    }

    public static class Patch_SystemText_Localize
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            string fr;
            if (id > 0 && LocoMotiveFRPlugin.DialoguesById.TryGetValue(id, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            if (!string.IsNullOrEmpty(defaultText))
            {
                string trans = LocoMotiveFRPlugin.TranslateString(defaultText);
                if (trans != defaultText)
                {
                    __result = trans;
                    return false;
                }
            }
            return true;
        }
    }

    public static class Patch_SystemText_LocalizeWithID
    {
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            string fr;
            if (id > 0 && LocoMotiveFRPlugin.DialoguesById.TryGetValue(id, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            if (!string.IsNullOrEmpty(defaultText))
            {
                string trans = LocoMotiveFRPlugin.TranslateString(defaultText);
                if (trans != defaultText)
                {
                    __result = trans;
                    return false;
                }
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
                    foreach (var l in newLangs)
                    {
                        if (l != null && (l.m_code == "fr" || l.m_description == "Français"))
                        {
                            hasFr = true;
                            break;
                        }
                    }
                    if (!hasFr)
                    {
                        var frLang = new PowerTools.Quest.LanguageData();
                        frLang.m_code = "fr";
                        frLang.m_description = "Français";
                        newLangs.Add(frLang);
                        fi.SetValue(__instance, newLangs.ToArray());
                        if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogInfo("-> Langue 'Français' ajoutée avec succès au menu des langues de SystemText !");
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
        public static void Prefix(ref string text)
        {
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }
}
