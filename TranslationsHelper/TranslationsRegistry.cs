using System.Collections.Generic;
using System.Linq;
using Jotunn;
using Jotunn.Utils;
using TranslationsHelper.models;

namespace TranslationsHelper;

public static class TranslationsRegistry
{
    public static readonly Dictionary<string, List<string>> ModPrefabTranslations = new();

    public static void Initialize()
    {
        Logger.LogInfo("scanning loaded prefabs for translations");
        Dictionary<string, List<string>> result = ModQuery.GetPrefabs()
            .GroupBy(pair => pair.SourceMod.Name)
            .ToDictionary(
                group => group.Key,
                group => group.SelectMany(GetPrefabTranslations).ToList()
            );
        foreach (KeyValuePair<string, List<string>> pair in result)
        {
            Logger.LogInfo($"adding {pair.Value.Count} translation strings for mod {pair.Key}");
            ModPrefabTranslations.Add(pair.Key, pair.Value);
        }
    }

    private static List<string> GetPrefabTranslations(IModPrefab prefab)
    {
        var strings = new List<string>();
        if (prefab.Prefab == null) return strings;
        Logger.LogInfo($"scanning prefab '{prefab.Prefab.name}' for translation");
        if (prefab.Prefab.TryGetComponent(out ItemDrop itemDrop))
            strings.AddRange(new CommonModel(itemDrop).Translate());
        if (prefab.Prefab.TryGetComponent(out Piece piece))
            strings.AddRange(new CommonModel(piece).Translate());
        if (prefab.Prefab.TryGetComponent(out Character character))
            strings.AddRange(new NameModel(character).Translate());
        if (prefab.Prefab.TryGetComponent(out Beehive beehive))
            strings.AddRange(new BeehiveModel(beehive).Translate());
        if (prefab.Prefab.TryGetComponent(out CookingStation cookingStation))
            strings.AddRange(new CookingStationModel(cookingStation).Translate());
        if (prefab.Prefab.TryGetComponent(out Fermenter fermenter))
            strings.AddRange(new FermenterModel(fermenter).Translate());
        if (prefab.Prefab.TryGetComponent(out Smelter smelter))
            strings.AddRange(new SmelterModel(smelter).Translate());
        if (prefab.Prefab.TryGetComponent(out Incinerator incinerator))
            strings.AddRange(new IncineratorModel(incinerator).Translate());
        if (prefab.Prefab.TryGetComponent(out MapTable mapTable))
            strings.AddRange(new MapTableModel(mapTable).Translate());
        if (prefab.Prefab.TryGetComponent(out OfferingBowl offeringBowl))
            strings.AddRange(new OfferingBowlModel(offeringBowl).Translate());
        if (prefab.Prefab.TryGetComponent(out SapCollector sapCollector))
            strings.AddRange(new SapCollectorModel(sapCollector).Translate());
        if (prefab.Prefab.TryGetComponent(out MineRock mineRock))
            strings.AddRange(new NameModel(mineRock).Translate());
        if (prefab.Prefab.TryGetComponent(out MineRock5 mineRock5))
            strings.AddRange(new NameModel(mineRock5).Translate());
        if (prefab.Prefab.TryGetComponent(out ItemStand itemStand))
            strings.AddRange(new NameModel(itemStand).Translate());
        if (prefab.Prefab.TryGetComponent(out Ladder ladder))
            strings.AddRange(new NameModel(ladder).Translate());
        if (prefab.Prefab.TryGetComponent(out Plant plant))
            strings.AddRange(new NameModel(plant).Translate());
        if (prefab.Prefab.TryGetComponent(out RuneStone runeStone))
            strings.AddRange(new RuneStoneModel(runeStone).Translate());
        if (prefab.Prefab.TryGetComponent(out ShipControlls shipControlls))
            strings.AddRange(new ShipControlModel(shipControlls).Translate());
        if (prefab.Prefab.TryGetComponent(out Teleport teleport))
            strings.AddRange(new TeleportModel(teleport).Translate());
        if (prefab.Prefab.TryGetComponent(out Switch switchObject))
            strings.AddRange(new SwitchModel(switchObject).Translate());
        if (prefab.Prefab.TryGetComponent(out ToggleSwitch toggleSwitch))
            strings.AddRange(new SwitchModel(toggleSwitch).Translate());
        if (prefab.Prefab.TryGetComponent(out HoverText hoverText))
            strings.AddRange(new NameModel(hoverText).Translate());
        if(prefab.Prefab.TryGetComponent(out Pickable pickable))
            strings.AddRange(new PickableModel(pickable).Translate());
        return strings;
    }
}