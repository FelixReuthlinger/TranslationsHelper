using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SapCollectorModel : NameModel
{
    public SapCollectorModel(SapCollector original) : base(internalName: original.name, nameToken: original.m_name)
    {
        DrainingSlowTextToken = original.m_drainingSlowText;
        DrainingTextToken = original.m_drainingText;
        ExtractTextToken = original.m_extractText;
        FullTextToken = original.m_fullText;
        NotConnectedTextToken = original.m_notConnectedText;
    }

    [UsedImplicitly] public readonly string DrainingSlowTextToken;
    [UsedImplicitly] public readonly string DrainingTextToken;
    [UsedImplicitly] public readonly string ExtractTextToken;
    [UsedImplicitly] public readonly string FullTextToken;
    [UsedImplicitly] public readonly string NotConnectedTextToken;

    public override List<string> Translate()
    {
        var sapCollectorTranslations = base.Translate();
        sapCollectorTranslations.AddRange(new List<string>
        {
            TranslateTokenToPair(DrainingTextToken),
            TranslateTokenToPair(DrainingSlowTextToken),
            TranslateTokenToPair(ExtractTextToken),
            TranslateTokenToPair(FullTextToken),
            TranslateTokenToPair(NotConnectedTextToken)
        });
        return sapCollectorTranslations;
    }
}