using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SwitchModel
{
    public SwitchModel(Switch original)
    {
        Name = original.m_name;
        HoverText = original.m_hoverText;
    }
    
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string HoverText;
    
}