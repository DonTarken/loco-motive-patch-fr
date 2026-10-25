using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using TMPro;

namespace LocoMotiveFR
{
    [BepInPlugin("org.dontarken.locomotive.fr", "Loco Motive Patch FR", "1.5.0")]
    public class LocoMotiveFRPlugin : BaseUnityPlugin
    {
        public static LocoMotiveFRPlugin Instance;
        public static BepInEx.Logging.ManualLogSource Log;
        public static Dictionary<string, string> TextByEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public static string TranslationDir;

        public static readonly int[] AvailableLanguageIds = new int[] { 0, 3, 1, 4 };
        public static int FrenchLanguageIndex = 4;

        void Awake()
        {
            Instance = this;
            Log = Logger;
            TranslationDir = Path.Combine(Paths.PluginPath, "LocoMotiveFR_Data");
            if (!Directory.Exists(TranslationDir))
            {
                TranslationDir = Path.Combine(Paths.GameRootPath, "Translations_FR");
            }

            Logger.LogInfo("=== [Loco Motive FR] Initialisation du patch v1.5.0 (UI, Tutoriels & Interactions)... ===");
            LoadTranslations();

            var harmony = new Harmony("org.dontarken.locomotive.fr");

            // Hooks pour les textes et dialogues
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

            // Hooks pour les composants UI et textes
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

            // Hooks pour les options de choix de dialogues
            PatchMethod(harmony, typeof(PowerTools.Quest.DialogOption), "get_Text", 
                Type.EmptyTypes,
                typeof(Patch_DialogOption_get_Text), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.DialogOption), "get_Description", 
                Type.EmptyTypes,
                typeof(Patch_DialogOption_get_Description), null, "Postfix");

            // Hooks pour le menu Pause & Boîtes de dialogue de confirmation (PromptBuilder)
            PatchMethod(harmony, typeof(PromptBuilder), "SetHeading",
                new Type[] { typeof(string) },
                typeof(Patch_PromptBuilder_SetHeading), "Prefix", null);

            PatchMethod(harmony, typeof(PromptBuilder), "SetLabel",
                new Type[] { typeof(string) },
                typeof(Patch_PromptBuilder_SetLabel), "Prefix", null);

            PatchMethod(harmony, typeof(PromptBuilder), "AddButton",
                new Type[] { typeof(string), typeof(Action) },
                typeof(Patch_PromptBuilder_AddButton), "Prefix", null);

            // Hooks pour les bulles de tutoriel (GuiTutorial)
            PatchMethod(harmony, typeof(GuiTutorial), "Show",
                new Type[] { typeof(string), typeof(Vector2) },
                typeof(Patch_GuiTutorial_Show), "Prefix", null);

            PatchMethod(harmony, typeof(GuiTutorial), "Refresh",
                new Type[] { typeof(string), typeof(Vector2) },
                typeof(Patch_GuiTutorial_Refresh), "Prefix", null);

            // Hooks pour les infobulles d'interactions (Tooltips & Slots)
            PatchConstructor(harmony, typeof(PowerTools.QuestGui.TooltipInfo),
                new Type[] { typeof(string), typeof(string) },
                typeof(Patch_TooltipInfo_ctor), "Prefix");

            PatchMethod(harmony, typeof(PowerTools.QuestGui.TooltipSlot), "Show",
                new Type[] { typeof(string) },
                typeof(Patch_TooltipSlot_Show), "Prefix", null);

            // Hooks pour les descriptions d'objets, éléments interactifs et personnages
            PatchMethod(harmony, typeof(PowerTools.Quest.Prop), "get_InteractDescription",
                Type.EmptyTypes,
                typeof(Patch_Prop_get_InteractDescription), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.Prop), "get_LookDescription",
                Type.EmptyTypes,
                typeof(Patch_Prop_get_LookDescription), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.Prop), "get_Description",
                Type.EmptyTypes,
                typeof(Patch_Prop_get_Description), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.Hotspot), "get_Description",
                Type.EmptyTypes,
                typeof(Patch_Hotspot_get_Description), null, "Postfix");

            PatchMethod(harmony, typeof(PowerTools.Quest.Character), "get_Description",
                Type.EmptyTypes,
                typeof(Patch_Character_get_Description), null, "Postfix");

            // Hooks pour le sélecteur de langue des Paramètres (4 langues)
            PatchMethod(harmony, typeof(GuiSettings), "OptTextLanguageL", 
                Type.EmptyTypes,
                typeof(Patch_GuiSettings_OptTextLanguageL), "Prefix", null);

            PatchMethod(harmony, typeof(GuiSettings), "OptTextLanguageR", 
                Type.EmptyTypes,
                typeof(Patch_GuiSettings_OptTextLanguageR), "Prefix", null);

            PatchMethod(harmony, typeof(GuiSettings), "RefreshTextLanguageDisplay", 
                Type.EmptyTypes,
                typeof(Patch_GuiSettings_RefreshTextLanguageDisplay), "Prefix", null);

            Logger.LogInfo(string.Format("=== [Loco Motive FR] Patch actif ! {0} entrées de texte chargées. ===", TextByEnglish.Count));
        }

        private static void PatchConstructor(Harmony harmony, Type targetType, Type[] parameters, Type patchType, string prefixName)
        {
            try
            {
                var target = AccessTools.Constructor(targetType, parameters);
                if (target == null)
                {
                    if (Log != null) Log.LogWarning(string.Format("Constructeur introuvable pour patch : {0}", targetType.Name));
                    return;
                }
                HarmonyMethod prefix = prefixName != null ? new HarmonyMethod(patchType, prefixName) : null;
                harmony.Patch(target, prefix, null);
                if (Log != null) Log.LogInfo(string.Format("-> Patch Harmony appliqué sur constructeur : {0}", targetType.Name));
            }
            catch (Exception ex)
            {
                if (Log != null) Log.LogError(string.Format("Erreur patch constructeur {0} : {1}", targetType.Name, ex.Message));
            }
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

        public static bool IsFrenchActive()
        {
            try
            {
                var pq = PowerTools.Quest.PowerQuest.Get;
                if (pq != null && pq.Settings != null)
                {
                    return pq.Settings.LanguageId == FrenchLanguageIndex;
                }
            }
            catch {}
            return true;
        }

        public static void CycleLanguage(GuiSettings guiSettings, int direction)
        {
            try
            {
                var pq = PowerTools.Quest.PowerQuest.Get;
                if (pq == null || pq.Settings == null) return;

                int currentId = pq.Settings.LanguageId;
                int currentIndex = Array.IndexOf(AvailableLanguageIds, currentId);
                if (currentIndex < 0) currentIndex = AvailableLanguageIds.Length - 1;

                int nextIndex = (currentIndex + direction + AvailableLanguageIds.Length) % AvailableLanguageIds.Length;
                int nextId = AvailableLanguageIds[nextIndex];

                pq.Settings.LanguageId = nextId;

                var globalScript = global::GlobalScriptBase<GlobalScript>.Script;
                if (globalScript != null)
                {
                    globalScript.OnLanguageChanged();
                }

                var saveMethod = AccessTools.Method(typeof(GuiSettings), "SaveLanguageSelection");
                if (saveMethod != null) saveMethod.Invoke(guiSettings, null);

                var refreshMethod = AccessTools.Method(typeof(GuiSettings), "Refresh");
                if (refreshMethod != null) refreshMethod.Invoke(guiSettings, null);

                if (Log != null) Log.LogInfo(string.Format("-> Langue changée vers ID {0} (index {1})", nextId, nextIndex));
            }
            catch (Exception ex)
            {
                if (Log != null) Log.LogError("Erreur CycleLanguage : " + ex.Message);
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
            if (!IsFrenchActive()) return input;

            string text = input;

            // Détection et suppression des tags ID de PowerQuest du style &403
            if (text.Length > 0 && text[0] == '&')
            {
                int spaceIdx = text.IndexOf(' ');
                if (spaceIdx > 1)
                {
                    int dummyId;
                    if (int.TryParse(text.Substring(1, spaceIdx - 1), out dummyId))
                    {
                        text = text.Substring(spaceIdx + 1);
                    }
                }
            }

            string trimmed = text.Trim();
            string fr;

            // 1. Recherche par (Personnage::Texte)
            if (!string.IsNullOrEmpty(character))
            {
                string charKey = character + "::" + trimmed;
                if (TextByEnglish.TryGetValue(charKey, out fr) && !string.IsNullOrEmpty(fr))
                {
                    return PreserveSpaces(text, fr);
                }
            }

            // 2. Recherche par texte direct
            if (TextByEnglish.TryGetValue(text, out fr) && !string.IsNullOrEmpty(fr))
            {
                return fr;
            }

            // 3. Recherche par texte rogné
            if (TextByEnglish.TryGetValue(trimmed, out fr) && !string.IsNullOrEmpty(fr))
            {
                return PreserveSpaces(text, fr);
            }

            // 4. Détection et extraction des balises <sprite...> (ex: icônes boutons souris/manette)
            if (trimmed.Contains("<sprite"))
            {
                var sprites = new List<string>();
                string template = Regex.Replace(trimmed, @"<sprite[^>]*>", match => {
                    sprites.Add(match.Value);
                    return "{" + (sprites.Count - 1) + "}";
                });

                if (TextByEnglish.TryGetValue(template.Trim(), out fr) && !string.IsNullOrEmpty(fr))
                {
                    for (int i = 0; i < sprites.Count; i++)
                    {
                        fr = fr.Replace("{" + i + "}", sprites[i]);
                    }
                    return PreserveSpaces(text, fr);
                }
            }

            // 5. Détection des balises de début <font=...> et <size=...>
            if (trimmed.StartsWith("<font=") || trimmed.StartsWith("<size="))
            {
                var match = Regex.Match(trimmed, @"^(<font=[^>]+>|<size=[^>]+>)+");
                if (match.Success)
                {
                    string prefix = match.Value;
                    string inner = trimmed.Substring(prefix.Length);
                    string translatedInner = TranslateString(inner, character);
                    if (translatedInner != inner)
                    {
                        return PreserveSpaces(text, prefix + translatedInner);
                    }
                }
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
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return true;

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
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return true;

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
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return true;

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
                    LocoMotiveFRPlugin.FrenchLanguageIndex = frIndex;

                    // Définir le français par défaut si le jeu était sur 0
                    try
                    {
                        var pq = PowerTools.Quest.PowerQuest.Get;
                        if (pq != null && pq.Settings != null && frIndex > 0)
                        {
                            if (pq.Settings.LanguageId == 0)
                            {
                                pq.Settings.LanguageId = frIndex;
                                if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogInfo(string.Format("-> Langue active initialisée sur Français (index {0}) !", frIndex));
                            }
                        }
                    }
                    catch {}
                }
            }
            catch (Exception ex)
            {
                if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogError("Erreur SystemText.Awake : " + ex.Message);
            }
        }
    }

    public static class Patch_QuestTextPro_SetText
    {
        public static void Prefix(ref string text)
        {
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    public static class Patch_LabelPro_set_Text
    {
        public static void Prefix(ref string value)
        {
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_Label_set_Text
    {
        public static void Prefix(ref string value)
        {
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_TMP_Text_set_text
    {
        public static void Prefix(ref string value)
        {
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    public static class Patch_TMP_Text_SetText
    {
        public static void Prefix(ref string sourceText)
        {
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            sourceText = LocoMotiveFRPlugin.TranslateString(sourceText);
        }
    }

    public static class Patch_DialogOption_get_Text
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;

            string trans = LocoMotiveFRPlugin.TranslateString(__result);
            if (trans != __result)
            {
                __result = trans;
            }
        }
    }

    public static class Patch_DialogOption_get_Description
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;

            string trans = LocoMotiveFRPlugin.TranslateString(__result);
            if (trans != __result)
            {
                __result = trans;
            }
        }
    }

    public static class Patch_GuiSettings_OptTextLanguageL
    {
        public static bool Prefix(GuiSettings __instance)
        {
            LocoMotiveFRPlugin.CycleLanguage(__instance, -1);
            return false;
        }
    }

    public static class Patch_GuiSettings_OptTextLanguageR
    {
        public static bool Prefix(GuiSettings __instance)
        {
            LocoMotiveFRPlugin.CycleLanguage(__instance, 1);
            return false;
        }
    }

    public static class Patch_GuiSettings_RefreshTextLanguageDisplay
    {
        public static bool Prefix(GuiSettings __instance)
        {
            try
            {
                var pq = PowerTools.Quest.PowerQuest.Get;
                if (pq != null && pq.Settings != null)
                {
                    int langId = pq.Settings.LanguageId;
                    string label = "FRANÇAIS";
                    if (langId == LocoMotiveFRPlugin.FrenchLanguageIndex || langId == 4)
                    {
                        label = "FRANÇAIS";
                    }
                    else
                    {
                        var data = pq.Settings.LanguageData;
                        if (data != null && !string.IsNullOrEmpty(data.m_description))
                            label = data.m_description.ToUpperInvariant();
                        else if (langId == 0) label = "ENGLISH (UK)";
                        else if (langId == 3) label = "ENGLISH (US)";
                        else if (langId == 1) label = "DEUTSCH";
                    }

                    var opt = __instance.Option("OptTextLanguage");
                    if (opt != null)
                    {
                        opt.Label = label;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (LocoMotiveFRPlugin.Log != null) LocoMotiveFRPlugin.Log.LogWarning("Erreur RefreshTextLanguageDisplay : " + ex.Message);
            }
            return true;
        }
    }

    public static class Patch_PromptBuilder_SetHeading
    {
        public static void Prefix(ref string heading)
        {
            if (string.IsNullOrEmpty(heading)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            heading = LocoMotiveFRPlugin.TranslateString(heading);
        }
    }

    public static class Patch_PromptBuilder_SetLabel
    {
        public static void Prefix(ref string label)
        {
            if (string.IsNullOrEmpty(label)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            label = LocoMotiveFRPlugin.TranslateString(label);
        }
    }

    public static class Patch_PromptBuilder_AddButton
    {
        public static void Prefix(ref string label)
        {
            if (string.IsNullOrEmpty(label)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            label = LocoMotiveFRPlugin.TranslateString(label);
        }
    }

    public static class Patch_GuiTutorial_Show
    {
        public static void Prefix(ref string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    public static class Patch_GuiTutorial_Refresh
    {
        public static void Prefix(ref string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    public static class Patch_TooltipInfo_ctor
    {
        public static void Prefix(ref string label, ref string sprite)
        {
            if (string.IsNullOrEmpty(label)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            label = LocoMotiveFRPlugin.TranslateString(label);
        }
    }

    public static class Patch_TooltipSlot_Show
    {
        public static void Prefix(ref string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    public static class Patch_Prop_get_InteractDescription
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            __result = LocoMotiveFRPlugin.TranslateString(__result);
        }
    }

    public static class Patch_Prop_get_LookDescription
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            __result = LocoMotiveFRPlugin.TranslateString(__result);
        }
    }

    public static class Patch_Prop_get_Description
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            __result = LocoMotiveFRPlugin.TranslateString(__result);
        }
    }

    public static class Patch_Hotspot_get_Description
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            __result = LocoMotiveFRPlugin.TranslateString(__result);
        }
    }

    public static class Patch_Character_get_Description
    {
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;
            if (!LocoMotiveFRPlugin.IsFrenchActive()) return;
            __result = LocoMotiveFRPlugin.TranslateString(__result);
        }
    }
}
