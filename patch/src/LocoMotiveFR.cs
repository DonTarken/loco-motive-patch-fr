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
    [BepInPlugin("org.dontarken.locomotive.fr", "Loco Motive Patch FR", "1.0.0")]
    public class LocoMotiveFRPlugin : BaseUnityPlugin
    {
        public static LocoMotiveFRPlugin Instance;
        public static Dictionary<int, string> DialoguesById = new Dictionary<int, string>();
        public static Dictionary<string, string> TextByEnglish = new Dictionary<string, string>(StringComparer.Ordinal);
        public static string TranslationDir;

        void Awake()
        {
            Instance = this;
            TranslationDir = Path.Combine(Paths.PluginPath, "LocoMotiveFR_Data");
            if (!Directory.Exists(TranslationDir))
            {
                TranslationDir = Path.Combine(Paths.GameRootPath, "Translations_FR");
            }

            Logger.LogInfo("=== [Loco Motive FR] Initialisation du patch français... ===");
            LoadTranslations();

            try
            {
                var harmony = new Harmony("org.dontarken.locomotive.fr");
                harmony.PatchAll();
                Logger.LogInfo(string.Format("=== [Loco Motive FR] Patch actif ! {0} répliques (ID) et {1} textes (EN) chargés. ===", DialoguesById.Count, TextByEnglish.Count));
            }
            catch (Exception ex)
            {
                Logger.LogError("[Loco Motive FR] Erreur lors de l'application des patches Harmony : " + ex.ToString());
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Logger.LogInfo("[Loco Motive FR] Rechargement à chaud des traductions (F5)...");
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
                    if (Instance != null)
                        Instance.Logger.LogError("Erreur lecture " + file + " : " + ex.Message);
                }
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
            if (TextByEnglish.TryGetValue(input, out fr) && !string.IsNullOrEmpty(fr))
            {
                return fr;
            }
            string trimmed = input.Trim();
            if (TextByEnglish.TryGetValue(trimmed, out fr) && !string.IsNullOrEmpty(fr))
            {
                return fr;
            }
            return input;
        }
    }

    [HarmonyPatch(typeof(PowerTools.Quest.SystemText), "GetDisplayText", new Type[] { typeof(string), typeof(int), typeof(string) })]
    public static class Patch_SystemText_GetDisplayText
    {
        [HarmonyPrefix]
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            string fr;
            if (id > 0 && LocoMotiveFRPlugin.DialoguesById.TryGetValue(id, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            if (!string.IsNullOrEmpty(defaultText) && LocoMotiveFRPlugin.TextByEnglish.TryGetValue(defaultText, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(PowerTools.Quest.SystemText), "Localize", new Type[] { typeof(string), typeof(int), typeof(string) })]
    public static class Patch_SystemText_Localize
    {
        [HarmonyPrefix]
        public static bool Prefix(ref string __result, string defaultText, int id, string characterName)
        {
            string fr;
            if (id > 0 && LocoMotiveFRPlugin.DialoguesById.TryGetValue(id, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            if (!string.IsNullOrEmpty(defaultText) && LocoMotiveFRPlugin.TextByEnglish.TryGetValue(defaultText, out fr) && !string.IsNullOrEmpty(fr))
            {
                __result = fr;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(PowerTools.Quest.QuestTextPro), "SetText", new Type[] { typeof(string) })]
    public static class Patch_QuestTextPro_SetText
    {
        [HarmonyPrefix]
        public static void Prefix(ref string text)
        {
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }

    [HarmonyPatch(typeof(TMP_Text), "text", MethodType.Setter)]
    public static class Patch_TMP_Text_Setter
    {
        [HarmonyPrefix]
        public static void Prefix(ref string value)
        {
            value = LocoMotiveFRPlugin.TranslateString(value);
        }
    }

    [HarmonyPatch(typeof(TMP_Text), "SetText", new Type[] { typeof(string), typeof(bool) })]
    public static class Patch_TMP_Text_SetText
    {
        [HarmonyPrefix]
        public static void Prefix(ref string text)
        {
            text = LocoMotiveFRPlugin.TranslateString(text);
        }
    }
}
