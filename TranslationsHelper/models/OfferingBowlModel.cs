using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class OfferingBowlModel: NameModel
{
    public OfferingBowlModel(OfferingBowl original) : base(internalName:original.name, nameToken:original.m_name)
    {
        UseItemTextToken = original.m_useItemText;
    }
    
    [UsedImplicitly] public readonly string UseItemTextToken;

    public override List<string> Translate()
    {
        var translations = base.Translate();
        translations.Add(TranslateTokenToPair(UseItemTextToken));
        return translations;
    }
}