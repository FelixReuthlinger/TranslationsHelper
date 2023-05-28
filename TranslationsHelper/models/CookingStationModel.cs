using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class CookingStationModel
{
    public CookingStationModel(CookingStation original)
    {
        AddFoodSwitch = new SwitchModel(original.m_addFoodSwitch);
        AddFuelSwitch = new SwitchModel(original.m_addFuelSwitch);
        AddItemTooltip = original.m_addItemTooltip;
        Name = original.m_name;
    }
        
    [UsedImplicitly] public readonly SwitchModel AddFoodSwitch;
    [UsedImplicitly] public readonly SwitchModel AddFuelSwitch;
    [UsedImplicitly] public readonly string AddItemTooltip;
    [UsedImplicitly] public readonly string Name;
}