using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class IncineratorModel : Translatable
{
    public IncineratorModel(Incinerator original)
    {
        Name = original.name;
        IncinerateSwitch = new SwitchModel(original.m_incinerateSwitch);
    }

    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly SwitchModel IncinerateSwitch;
    public override List<string> Translate()
    {
        return IncinerateSwitch.Translate();
    }
}