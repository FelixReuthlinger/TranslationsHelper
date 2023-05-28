using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class IncineratorModel
{
    public IncineratorModel(Incinerator original)
    {
        IncinerateSwitch = new SwitchModel(original.m_incinerateSwitch);
    }
    
    [UsedImplicitly] public readonly SwitchModel IncinerateSwitch;
}