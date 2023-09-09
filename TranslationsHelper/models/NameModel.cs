using System.Collections.Generic;
using JetBrains.Annotations;
using Jotunn;

namespace TranslationsHelper.models;

public class NameModel : Translatable
{
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string TranslationNameToken;

    public NameModel(string internalName, string nameToken)
    {
        Name = internalName;
        TranslationNameToken = nameToken;
    }

    public NameModel(Character fromCharacter) : this(fromCharacter.name, fromCharacter.m_name)
    {
    }

    public NameModel(HoverText fromHoverText) : this(internalName: fromHoverText.name, nameToken: fromHoverText.m_text)
    {
    }

    public override List<string> Translate()
    {
        Logger.LogInfo($"translating {Name} to {TranslateTokenToPair(TranslationNameToken)}");
        return new List<string>
        {
            TranslateTokenToPair(TranslationNameToken)
        };
    }
}