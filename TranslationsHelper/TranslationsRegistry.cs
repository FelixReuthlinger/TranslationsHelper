using System.Collections.Generic;
using System.Linq;
using Jotunn.Utils;
using TranslationsHelper.models;

namespace TranslationsHelper;

public static class TranslationsRegistry
{
    public static readonly Dictionary<string, List<string>> ModPrefabTranslations = new();

    public static void Initialize()
    {
        var result = ModQuery.GetPrefabs()
            .GroupBy(pair => pair.SourceMod.Name)
            .ToDictionary(
                group => group.Key,
                group => group.SelectMany(prefab =>
                    {
                        if (prefab.Prefab.TryGetComponent(out ItemDrop itemDrop))
                            return new CommonModel(itemDrop).Translate();
                        if (prefab.Prefab.TryGetComponent(out Piece piece))
                            return new CommonModel(piece).Translate();
                        if (prefab.Prefab.TryGetComponent(out Character character))
                            return new NameModel(character).Translate();
                        if (prefab.Prefab.TryGetComponent(out Beehive beehive))
                            return new BeehiveModel(beehive).Translate();
                        if (prefab.Prefab.TryGetComponent(out CookingStation cookingStation))
                            return new CookingStationModel(cookingStation).Translate();
                        if (prefab.Prefab.TryGetComponent(out Fermenter fermenter))
                            return new FermenterModel(fermenter).Translate();
                        if (prefab.Prefab.TryGetComponent(out Smelter smelter))
                            return new SmelterModel(smelter).Translate();
                        if (prefab.Prefab.TryGetComponent(out Incinerator incinerator))
                            return new IncineratorModel(incinerator).Translate();
                        if (prefab.Prefab.TryGetComponent(out MapTable mapTable))
                            return new MapTableModel(mapTable).Translate();
                        if (prefab.Prefab.TryGetComponent(out OfferingBowl offeringBowl))
                            return new OfferingBowlModel(offeringBowl).Translate();
                        if (prefab.Prefab.TryGetComponent(out SapCollector sapCollector))
                            return new SapCollectorModel(sapCollector).Translate();
                        if (prefab.Prefab.TryGetComponent(out MineRock mineRock)) 
                            return new NameModel(mineRock).Translate();
                        if (prefab.Prefab.TryGetComponent(out MineRock5 mineRock5)) 
                            return new NameModel(mineRock5).Translate();
                        if (prefab.Prefab.TryGetComponent(out ItemStand itemStand)) 
                            return new NameModel(itemStand).Translate();
                        if (prefab.Prefab.TryGetComponent(out Ladder ladder)) 
                            return new NameModel(ladder).Translate();
                        if (prefab.Prefab.TryGetComponent(out Plant plant)) 
                            return new NameModel(plant).Translate();
                        if (prefab.Prefab.TryGetComponent(out RuneStone runeStone)) 
                            return new RuneStoneModel(runeStone).Translate();
                        if (prefab.Prefab.TryGetComponent(out ShipControlls shipControlls)) 
                            return new ShipControlModel(shipControlls).Translate();
                        if (prefab.Prefab.TryGetComponent(out Teleport teleport)) 
                            return new TeleportModel(teleport).Translate();
                        if (prefab.Prefab.TryGetComponent(out Switch switchObject)) 
                            return new SwitchModel(switchObject).Translate();
                        if (prefab.Prefab.TryGetComponent(out ToggleSwitch toggleSwitch)) 
                            return new SwitchModel(toggleSwitch).Translate();
                        if (prefab.Prefab.TryGetComponent(out HoverText hoverText))
                            return new NameModel(hoverText).Translate();
                        return new List<string>();
                    }
                ).Distinct().ToList()
            );
        foreach (KeyValuePair<string, List<string>> pair in result)
        {
            ModPrefabTranslations.Add(pair.Key, pair.Value);
        }
    }
}