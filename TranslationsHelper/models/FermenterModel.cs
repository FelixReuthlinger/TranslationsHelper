using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class FermenterModel : NameModel
{
    public FermenterModel(Fermenter original) : base(internalName: original.name, nameToken: original.m_name)
    {
        AddSwitch = new SwitchModel(original.m_addSwitch);
        TapSwitch = new SwitchModel(original.m_tapSwitch);
    }

    [UsedImplicitly] public readonly SwitchModel AddSwitch;
    [UsedImplicitly] public readonly SwitchModel TapSwitch;

    public override List<string> Translate()
    {
        List<string> fermenterTranslations = base.Translate();
        fermenterTranslations.AddRange(AddSwitch.Translate());
        fermenterTranslations.AddRange(TapSwitch.Translate());
        return fermenterTranslations;
    }
}