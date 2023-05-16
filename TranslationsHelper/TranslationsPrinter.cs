using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using Jotunn;

namespace TranslationsHelper;

public static class TranslationsPrinter
{
    private static readonly string OutputPath = Path.Combine(Paths.BepInExRootPath, "TranslationsPrinterOutput");
    private const string FileSuffix = ".English.yml";

    public static void WriteData(string prefabNamePrefixFilter)
    {
        IEnumerable<KeyValuePair<string, List<string>>> filteredData = prefabNamePrefixFilter == ""
            ? TranslationsRegistry.ModPrefabTranslations
            : TranslationsRegistry.ModPrefabTranslations
                .Where(pair => pair.Key.StartsWith(prefabNamePrefixFilter));

        foreach (KeyValuePair<string, List<string>> modGroup in filteredData)
        {
            if (modGroup.Value.Count > 0)
            {
                string fileNamePath = Path.Combine(OutputPath, $"{modGroup.Key}{FileSuffix}");
                var fixedOutputs = modGroup.Value
                    .Where(line => line != "")
                    .Distinct()
                    .OrderBy(line => line)
                    .ToList();
                WriteFile(fixedOutputs, fileNamePath);
            }
            else
                Logger.LogWarning($"mod '{modGroup.Key}' does not contain any prefabs for translation");
        }
    }

    private static void WriteFile(List<string> translations, string filPath)
    {
        if (!Directory.Exists(OutputPath)) Directory.CreateDirectory(OutputPath);

        File.WriteAllText(filPath, string.Join("\n", translations));
        Logger.LogInfo($"wrote {translations.Count} translations to file '{filPath}'");
    }
}