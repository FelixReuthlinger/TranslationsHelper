using System.Collections.Generic;
using System.Security.Permissions;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class MapTableModel : NameModel
{
    public MapTableModel(MapTable original) : base(internalName: original.name, nameToken: original.m_name)
    {
        ReadSwitch = new SwitchModel(original.m_readSwitch);
        WriteSwitch = new SwitchModel(original.m_writeSwitch);
    }

    [UsedImplicitly] public readonly SwitchModel ReadSwitch;
    [UsedImplicitly] public readonly SwitchModel WriteSwitch;

    public override List<string> Translate()
    {
        List<string> mapTableTranslations = base.Translate();
        
        return mapTableTranslations;
    }
}