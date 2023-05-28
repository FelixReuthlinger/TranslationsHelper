using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class MapTableModel
{
    public MapTableModel(MapTable original)
    {
        Name = original.m_name;
        ReadSwitch = new SwitchModel(original.m_readSwitch);
        WriteSwitch = new SwitchModel(original.m_writeSwitch);
    }
    
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly SwitchModel ReadSwitch;
    [UsedImplicitly] public readonly SwitchModel WriteSwitch;
}