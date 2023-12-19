using System.Collections.Generic;
using System.Linq;
using Jotunn.Utils;
using TranslationsHelper.models;
using UnityEngine;
using Logger = Jotunn.Logger;

namespace TranslationsHelper;

public static class TranslationsRegistry
{
    public static readonly Dictionary<string, List<string>> ModPrefabTranslations = new();

    private static Dictionary<string, List<GameObject>> LoadScenePrefabs()
    {
        HashSet<GameObject> rarePrefabs = new HashSet<GameObject>(ZNetScene.instance.m_prefabs);
        HashSet<GameObject> namedPrefabs = new HashSet<GameObject>(ZNetScene.instance.m_namedPrefabs.Values);
        List<GameObject> combinedPrefabs = rarePrefabs.Union(namedPrefabs).ToList();
        combinedPrefabs.RemoveAll(prefab => !prefab);
        
        List<IModPrefab> modPrefabList = ModQuery.GetPrefabs().ToList();
        Dictionary<string, List<GameObject>> prefabs = new Dictionary<string, List<GameObject>>();
        
        foreach (var gameObject in combinedPrefabs)
        {
            IModPrefab? foundModdedPrefab = modPrefabList.Find(modPrefab => modPrefab.Prefab.name == gameObject.name);
            string modName = foundModdedPrefab != null ? foundModdedPrefab.SourceMod.Name : "vanilla";
            var list = prefabs.TryGetValue(modName, out var existingList) ? existingList : new List<GameObject>(); 
            list.Add(gameObject);
            prefabs[modName] = list;
        }
        
        return prefabs;
    }
    
    public static void Initialize()
    {
        if (ModPrefabTranslations.Any()) return;
        Logger.LogInfo("scanning loaded prefabs for translations");

        Dictionary<string, List<GameObject>> prefabs = LoadScenePrefabs();
        foreach (var modPrefab in prefabs)
        {
            Logger.LogInfo($"processing mod '{modPrefab.Key}'");
            List<string> translations = modPrefab.Value.SelectMany(GetPrefabTranslations).ToList();
            Logger.LogInfo($"adding {translations.Count} translation strings for mod {modPrefab.Key}");
            ModPrefabTranslations.Add(modPrefab.Key, translations);
        }
    }

    private static List<string> GetPrefabTranslations(GameObject prefab)
    {
        var strings = new List<string>();
        if (prefab == null) return strings;
        if (prefab.TryGetComponent(out ItemDrop itemDrop))
            strings.AddRange(new CommonModel(itemDrop).Translate());
        if (prefab.TryGetComponent(out Piece piece))
            strings.AddRange(new CommonModel(piece).Translate());
        if (prefab.TryGetComponent(out Character character))
            strings.AddRange(new NameModel(character).Translate());
        if (prefab.TryGetComponent(out Beehive beehive))
            strings.AddRange(new BeehiveModel(beehive).Translate());
        if (prefab.TryGetComponent(out CookingStation cookingStation))
            strings.AddRange(new CookingStationModel(cookingStation).Translate());
        if (prefab.TryGetComponent(out Fermenter fermenter))
            strings.AddRange(new FermenterModel(fermenter).Translate());
        if (prefab.TryGetComponent(out Smelter smelter))
            strings.AddRange(new SmelterModel(smelter).Translate());
        if (prefab.TryGetComponent(out Incinerator incinerator))
            strings.AddRange(new IncineratorModel(incinerator).Translate());
        if (prefab.TryGetComponent(out MapTable mapTable))
            strings.AddRange(new MapTableModel(mapTable).Translate());
        if (prefab.TryGetComponent(out OfferingBowl offeringBowl))
            strings.AddRange(new OfferingBowlModel(offeringBowl).Translate());
        if (prefab.TryGetComponent(out SapCollector sapCollector))
            strings.AddRange(new SapCollectorModel(sapCollector).Translate());
        if (prefab.TryGetComponent(out MineRock mineRock))
            strings.AddRange(new NameModel(mineRock).Translate());
        if (prefab.TryGetComponent(out MineRock5 mineRock5))
            strings.AddRange(new NameModel(mineRock5).Translate());
        if (prefab.TryGetComponent(out ItemStand itemStand))
            strings.AddRange(new NameModel(itemStand).Translate());
        if (prefab.TryGetComponent(out Ladder ladder))
            strings.AddRange(new NameModel(ladder).Translate());
        if (prefab.TryGetComponent(out Plant plant))
            strings.AddRange(new NameModel(plant).Translate());
        if (prefab.TryGetComponent(out RuneStone runeStone))
            strings.AddRange(new RuneStoneModel(runeStone).Translate());
        if (prefab.TryGetComponent(out ShipControlls shipControlls))
            strings.AddRange(new ShipControlModel(shipControlls).Translate());
        if (prefab.TryGetComponent(out Teleport teleport))
            strings.AddRange(new TeleportModel(teleport).Translate());
        if (prefab.TryGetComponent(out Switch switchObject))
            strings.AddRange(new SwitchModel(switchObject).Translate());
        if (prefab.TryGetComponent(out ToggleSwitch toggleSwitch))
            strings.AddRange(new SwitchModel(toggleSwitch).Translate());
        if (prefab.TryGetComponent(out HoverText hoverText))
            strings.AddRange(new NameModel(hoverText).Translate());
        Logger.LogInfo($"found {strings.Count} translations for '{prefab.name}'");
        return strings;
    }
}