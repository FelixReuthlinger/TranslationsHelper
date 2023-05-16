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
                        return new List<string>();
                    }
                ).ToList()
            );
        foreach (KeyValuePair<string, List<string>> pair in result)
        {
            ModPrefabTranslations.Add(pair.Key, pair.Value);
        }
    }
}