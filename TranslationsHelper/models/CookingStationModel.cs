using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class CookingStationModel : NameModel
{
    public CookingStationModel(CookingStation original) : base(internalName: original.name, nameToken: original.m_name)
    {
        AddFoodSwitch = new SwitchModel(original.m_addFoodSwitch);
        AddFuelSwitch = new SwitchModel(original.m_addFuelSwitch);
        AddItemTooltipToken = original.m_addItemTooltip;
    }
        
    [UsedImplicitly] public readonly SwitchModel AddFoodSwitch;
    [UsedImplicitly] public readonly SwitchModel AddFuelSwitch;
    [UsedImplicitly] public readonly string AddItemTooltipToken;

    public override List<string> Translate()
    {
        List<string> stationTranslations =  new List<string>
        {
            TranslateTokenToPair(TranslationNameToken),
            TranslateTokenToPair(AddItemTooltipToken)
        };
        stationTranslations.AddRange(AddFoodSwitch.Translate());
        stationTranslations.AddRange(AddFuelSwitch.Translate());
        return stationTranslations;
    }
}