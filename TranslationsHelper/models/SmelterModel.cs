using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SmelterModel
{
    public SmelterModel(Smelter original)
    {
        Name = original.m_name;
    }
    
    [UsedImplicitly] public readonly SwitchModel AddOreSwitch;
    [UsedImplicitly] public readonly string AddOreTooltip;
    [UsedImplicitly] public readonly SwitchModel AddWoodSwitch;
    [UsedImplicitly] public readonly SwitchModel EmptyOreSwitch;
    [UsedImplicitly] public readonly string EmptyOreTooltip;
    [UsedImplicitly] public readonly string Name;
}