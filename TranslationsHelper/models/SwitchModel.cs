using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SwitchModel : NameModel
{
    public SwitchModel(Switch original) : base(internalName: original.name, nameToken: original.m_name)
    {
        HoverTextToken = original.m_hoverText;
    }
    
    public SwitchModel(ToggleSwitch original) : base(internalName: original.name, nameToken: original.m_name)
    {
        HoverTextToken = original.m_hoverText;
    }

    [UsedImplicitly] public readonly string HoverTextToken;

    public override List<string> Translate()
    {
        return new List<string>
        {
            TranslateTokenToPair(TranslationNameToken),
            TranslateTokenToPair(HoverTextToken)
        };
    }
}