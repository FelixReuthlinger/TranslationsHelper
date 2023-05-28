using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class BeehiveModel
{
    public BeehiveModel(Beehive original)
    {
        AreaText = original.m_areaText;
        BlockedText = original.m_blockedText;
        CheckText = original.m_checkText;
        ExtractText = original.m_extractText;
        FreeSpaceText = original.m_freespaceText;
        HappyText = original.m_happyText;
        Name = original.m_name;
        NotConnectedText = original.m_notConnectedText;
        SleepText = original.m_sleepText;
    }

    [UsedImplicitly] public readonly string AreaText;
    [UsedImplicitly] public readonly string BlockedText;
    [UsedImplicitly] public readonly string CheckText;
    [UsedImplicitly] public readonly string ExtractText;
    [UsedImplicitly] public readonly string FreeSpaceText;
    [UsedImplicitly] public readonly string HappyText;
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string NotConnectedText;
    [UsedImplicitly] public readonly string SleepText;
}