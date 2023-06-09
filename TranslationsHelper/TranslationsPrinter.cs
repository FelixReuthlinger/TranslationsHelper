﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Jotunn;
using Jotunn.Managers;
using Jotunn.Utils;
using TranslationsHelper.models;
using Paths = BepInEx.Paths;

namespace TranslationsHelper
{
    public static class TranslationsPrinter
    {
        private static readonly Dictionary<string, Dictionary<string, string>> Translations =
            TransformPrefabsToTranslationsPerMod();

        private const string Vanilla = "vanilla";
        private static readonly string OutputPath = Path.Combine(Paths.ConfigPath, "TranslationsPrinterOutput");
        private const string FileSuffix = ".English.yml";

        public static void WriteData(string prefabNamePrefixFilter)
        {
            Dictionary<string, Dictionary<string, string>> filteredTranslations =
                Translations.ToDictionary(modPrefabs => modPrefabs.Key,
                    modPrefabs =>
                        modPrefabs.Value.Where(pair => pair.Key.StartsWith(prefabNamePrefixFilter))
                            .ToDictionary(pair => pair.Key, pair => pair.Value));

            foreach (KeyValuePair<string, Dictionary<string, string>> modGroup in filteredTranslations)
            {
                int prefabCount = modGroup.Value.Count;
                if (prefabCount > 0)
                {
                    Logger.LogInfo(
                        $"mod '{modGroup.Key}' - filtering prefab name using the prefix {prefabNamePrefixFilter} " +
                        $"did yield {prefabCount} found prefabs");
                    WriteData(modGroup.Value, Path.Combine(OutputPath, $"{modGroup.Key}{FileSuffix}"));
                }
                else
                {
                    Logger.LogWarning(
                        $"filtering prefab name using the prefix {prefabNamePrefixFilter} " +
                        $"did NOT yield any prefabs, skipping to write file!");
                }
            }
        }

        public static void WriteData()
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> modGroup in Translations)
            {
                if (modGroup.Value.Count > 0)
                {
                    WriteData(modGroup.Value, Path.Combine(OutputPath, $"{modGroup.Key}{FileSuffix}"));
                }
            }
        }

        private static void WriteData(Dictionary<string, string> translations, string filPath)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            Logger.LogInfo($"writing {translations.Count} entries to file '{filPath}'");
            var fileContent = "";
            var sortedKeys = translations.Keys.OrderBy(k => k);
            foreach (var key in sortedKeys)
            {
                fileContent += $"{key}: \"{translations[key]}\"\n";
            }

            File.WriteAllText(filPath, fileContent);
            Logger.LogInfo($"wrote content to file '{filPath}'");
        }

        private static Dictionary<string, CommonModel> ListAllTranslations()
        {
            LocalizationManager.Instance.GetLocalization().GetTranslations(LocalizationManager.DefaultLanguage);

            List<Dictionary<string, CommonModel>> results = new()
            {
                PrefabManager.Cache.GetPrefabs(typeof(ItemDrop))
                    .ToDictionary(pair => pair.Key, pair => new CommonModel((ItemDrop)pair.Value)),
                PrefabManager.Cache.GetPrefabs(typeof(Piece))
                    .ToDictionary(pair => pair.Key, pair => new CommonModel((Piece)pair.Value)),
            };
            return results.SelectMany(dict => dict)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.First());
        }


        private static Dictionary<string, string> RegisterPrefabMods()
        {
            return ModQuery.GetPrefabs()
                .ToLookup(modPrefab => modPrefab.Prefab.name, modPrefab => modPrefab.SourceMod.Name)
                .ToDictionary(group => group.Key, group => group.First());
        }

        private static Dictionary<string, Dictionary<string, string>> TransformPrefabsToTranslationsPerMod()
        {
            Dictionary<string, string> prefabModMapping = RegisterPrefabMods();
            Dictionary<string, CommonModel> translations = ListAllTranslations();
            Dictionary<string, Dictionary<string, string>> results = new();
            var prefabsGroupedPerMod = translations
                .GroupBy(pair => prefabModMapping.TryGetValue(pair.Key, out var modName) ? modName : Vanilla);
            foreach (var modGroup in prefabsGroupedPerMod.Where(group => group.Key != Vanilla))
            {
                string modName = modGroup.Key;
                Dictionary<string, CommonModel> modPrefabs =
                    modGroup.ToDictionary(pair => pair.Key, pair => pair.Value);
                Dictionary<string, string> translatedNames =
                    modPrefabs.ToDictionary(pair => pair.Value.Name,
                        pair => $"{pair.Value.TranslatedName}");
                Dictionary<string, string> translatedDescriptions =
                    modPrefabs.ToDictionary(pair => pair.Value.Name + "_Description",
                        pair => $"{pair.Value.TranslatedDescription}");
                results.Add(modName,
                    translatedNames.Concat(translatedDescriptions).ToDictionary(s => s.Key, s => s.Value));
            }

            return results;
        }
    }
}