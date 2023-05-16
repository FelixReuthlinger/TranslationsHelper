using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class OfferingBowlModel: NameModel
{
    public OfferingBowlModel(OfferingBowl original) : base(internalName:original.name, nameToken:original.m_name)
    {
        ItemStandPrefixToken = original.m_itemStandPrefix;
        UseItemTextToken = original.m_useItemText;
    }
    
    [UsedImplicitly] public readonly string ItemStandPrefixToken;
    [UsedImplicitly] public readonly string UseItemTextToken;

    public override List<string> Translate()
    {
        var itemStandTranslations = base.Translate();
        itemStandTranslations.Add(TranslateTokenToPair(ItemStandPrefixToken));
        itemStandTranslations.Add(TranslateTokenToPair(UseItemTextToken));
        return itemStandTranslations;
    }
}