using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class TeleportModel : Translatable
{
    public TeleportModel(Teleport original)
    {
        Name = original.name;
        HoverText = original.m_hoverText;
        EnterText = original.m_enterText;
    }

    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string HoverText;
    [UsedImplicitly] public readonly string EnterText;

    public override List<string> Translate()
    {
        return new List<string> { TranslateTokenToPair(HoverText), TranslateTokenToPair(EnterText) };
    }
}