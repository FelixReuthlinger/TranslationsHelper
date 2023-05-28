using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class OfferingBowlModel
{
    public OfferingBowlModel(OfferingBowl original)
    {
        Name = original.m_name;
        ItemStandPrefix = original.m_itemStandPrefix;
    }
    
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string ItemStandPrefix;
}