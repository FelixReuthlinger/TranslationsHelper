using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SapCollectorModel
{
    public SapCollectorModel(SapCollector original)
    {
        Name = original.m_name;
        DrainingSlowText = original.m_drainingSlowText;
        DrainingText = original.m_drainingText;
        ExtractText = original.m_extractText;
        FullText = original.m_fullText;
        NotConnectedText = original.m_notConnectedText;
    }
    
    [UsedImplicitly] public readonly string DrainingSlowText;
    [UsedImplicitly] public readonly string DrainingText;
    [UsedImplicitly] public readonly string ExtractText;
    [UsedImplicitly] public readonly string FullText;
    [UsedImplicitly] public readonly string NotConnectedText;
    [UsedImplicitly] public readonly string Name;
}