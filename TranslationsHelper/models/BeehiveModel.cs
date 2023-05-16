using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class BeehiveModel : NameModel
{
    public BeehiveModel(Beehive original) : base(internalName: original.name, nameToken: original.m_name)
    {
        AreaTextToken = original.m_areaText;
        BlockedTextToken = original.m_blockedText;
        CheckTextToken = original.m_checkText;
        ExtractTextToken = original.m_extractText;
        FreeSpaceTextToken = original.m_freespaceText;
        HappyTextToken = original.m_happyText;
        NotConnectedTextToken = original.m_notConnectedText;
        SleepTextToken = original.m_sleepText;
    }

    [UsedImplicitly] public readonly string AreaTextToken;
    [UsedImplicitly] public readonly string BlockedTextToken;
    [UsedImplicitly] public readonly string CheckTextToken;
    [UsedImplicitly] public readonly string ExtractTextToken;
    [UsedImplicitly] public readonly string FreeSpaceTextToken;
    [UsedImplicitly] public readonly string HappyTextToken;
    [UsedImplicitly] public readonly string NotConnectedTextToken;
    [UsedImplicitly] public readonly string SleepTextToken;

    public override List<string> Translate()
    {
        List<string> beehiveTranslations = base.Translate();
        beehiveTranslations.AddRange(new List<string>
        {
            TranslateTokenToPair(TranslationNameToken),
            TranslateTokenToPair(AreaTextToken),
            TranslateTokenToPair(BlockedTextToken),
            TranslateTokenToPair(CheckTextToken),
            TranslateTokenToPair(ExtractTextToken),
            TranslateTokenToPair(FreeSpaceTextToken),
            TranslateTokenToPair(HappyTextToken),
            TranslateTokenToPair(NotConnectedTextToken),
            TranslateTokenToPair(SleepTextToken)
        });
        return beehiveTranslations;
    }
}