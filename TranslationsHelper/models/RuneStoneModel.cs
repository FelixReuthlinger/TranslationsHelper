using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class RuneStoneModel : NameModel
{
    public RuneStoneModel(RuneStone original) : base(internalName: original.name, nameToken: original.m_name)
    {
        TextToken = original.m_text;
        TopicToken = original.m_topic;
        LabelToken = original.m_label;
    }

    [UsedImplicitly] public readonly string TextToken;
    [UsedImplicitly] public readonly string TopicToken;
    [UsedImplicitly] public readonly string LabelToken;

    public override List<string> Translate()
    {
        List<string> translations = base.Translate();
        translations.AddRange(new List<string>
        {
            TranslateTokenToPair(TextToken),
            TranslateTokenToPair(TopicToken),
            TranslateTokenToPair(LabelToken)
        });
        return translations;
    }
}