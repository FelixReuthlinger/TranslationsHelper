using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class FermenterModel
{
    public FermenterModel(Fermenter original)
    {
        Name = original.m_name;
        AddSwitch = new SwitchModel(original.m_addSwitch);
        TapSwitch = new SwitchModel(original.m_tapSwitch);
    }
    
    [UsedImplicitly] public readonly SwitchModel AddSwitch;
    [UsedImplicitly] public readonly SwitchModel TapSwitch;
    [UsedImplicitly] public readonly string Name;
}