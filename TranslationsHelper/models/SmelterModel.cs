using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class SmelterModel : NameModel
{
    public SmelterModel(Smelter original) : base(internalName: original.name, nameToken: original.m_name)
    {
        AddOreSwitch = new SwitchModel(original.m_addOreSwitch);
        AddOreTooltipToken = original.m_addOreTooltip;
        AddWoodSwitch = new SwitchModel(original.m_addWoodSwitch);
        EmptyOreSwitch = new SwitchModel(original.m_emptyOreSwitch);
        EmptyOreTooltipToken = original.m_emptyOreTooltip;
    }

    [UsedImplicitly] public readonly SwitchModel AddOreSwitch;
    [UsedImplicitly] public readonly string AddOreTooltipToken;
    [UsedImplicitly] public readonly SwitchModel AddWoodSwitch;
    [UsedImplicitly] public readonly SwitchModel EmptyOreSwitch;
    [UsedImplicitly] public readonly string EmptyOreTooltipToken;

    public override List<string> Translate()
    {
        var smelterTranslations = base.Translate();
        smelterTranslations.AddRange(new List<string>
        {
            TranslateTokenToPair(AddOreTooltipToken),
            TranslateTokenToPair(EmptyOreTooltipToken)
        });
        smelterTranslations.AddRange(AddWoodSwitch.Translate());
        smelterTranslations.AddRange(EmptyOreSwitch.Translate());
        return smelterTranslations;
    }
}