using BepInEx;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;

namespace TranslationsHelper
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Main.ModGuid)]
    public class TranslationsHelperPlugin : BaseUnityPlugin
    {
        private const string PluginAuthor = "FixItFelix";
        private const string PluginName = "TranslationsHelper";
        internal const string PluginVersion = "1.1.0";
        internal const string PluginGuid = PluginAuthor + "." + PluginName;

        private void Awake()
        {
            ModQuery.Enable();
            // PrefabManager.OnPrefabsRegistered += TranslationsRegistry.Initialize;
            CommandManager.Instance.AddConsoleCommand(new TranslationsPrinterController());
        }
    }

    public class TranslationsPrinterController : ConsoleCommand
    {
        public override void Run(string[] args)
        {
            TranslationsRegistry.Initialize();
            if (args.Length > 0)
            {
                Logger.LogInfo($"TranslationsPrinterController called with args '{string.Join(" - ", args)}'");
                TranslationsPrinter.WriteData(args[0]);
            }
            else
            {
                TranslationsPrinter.WriteData("");
            }
        }

        public override string Name => "print_translations_to_file";

        public override string Help =>
            "Write all prefabs loaded in-game into a YAML translations template file inside the " +
            "BepInEx config folder 'TranslationsPrinterOutput'.";
    }
}