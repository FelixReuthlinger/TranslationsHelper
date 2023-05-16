using BepInEx;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TranslationsHelper
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Main.ModGuid)]
    public class TranslationsHelperPlugin : BaseUnityPlugin
    {
        private const string PluginAuthor = "FixItFelix";
        private const string PluginName = "TranslationsHelper";
        private const string PluginVersion = "1.0.0";
        public const string PluginGuid = PluginAuthor + "." + PluginName;

        private void Awake()
        {
            CommandManager.Instance.AddConsoleCommand(new TranslationsPrinterController());
        }
    }

    public class TranslationsPrinterController : ConsoleCommand
    {
        public override void Run(string[] args)
        {
            Logger.LogInfo($"TranslationsPrinterController called with args '{string.Join(" - ", args)}'");
            if (args.Length > 0)
            {
                TranslationsPrinter.WriteData(args[0]);
            }
            else
            {
                TranslationsPrinter.WriteData();
            }
        }

        public override string Name => "print_translations_to_file";

        public override string Help =>
            "Write all prefabs loaded in-game into a YAML translations template file inside the " +
            "BepInEx config folder 'TranslationsPrinterOutput'.";
    }
}