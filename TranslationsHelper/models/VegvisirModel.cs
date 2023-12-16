using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class VegvisirModel : NameModel
{
    public VegvisirModel(Vegvisir original) : base(internalName: original.name, nameToken: original.m_name)
    {
        HoverName = original.m_hoverName;
        UseText = original.m_useText;
    }

    [UsedImplicitly] public readonly string HoverName;
    [UsedImplicitly] public readonly string UseText;

    public override List<string> Translate()
    {
        List<string> translations = base.Translate();
        translations.AddRange(new List<string>
        {
            TranslateTokenToPair(HoverName), TranslateTokenToPair(UseText)
        });
        return translations;
    }
}