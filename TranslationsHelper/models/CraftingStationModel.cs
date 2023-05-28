using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class CraftingStationModel
{
    public CraftingStationModel(CraftingStation original)
    {
        Name = original.m_name;
    }
    
    [UsedImplicitly] public readonly string Name;
}