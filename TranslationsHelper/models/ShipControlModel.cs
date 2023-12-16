using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class ShipControlModel : Translatable
{
    public ShipControlModel(ShipControlls original)
    {
        Name = original.name;
        HoverText = original.m_hoverText;
    }

    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string HoverText;

    public override List<string> Translate()
    {
        return new List<string> { TranslateTokenToPair(HoverText) };
    }
}