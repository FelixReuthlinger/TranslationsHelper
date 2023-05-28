using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class FireplaceModel
{
    public FireplaceModel(Fireplace original)
    {
        Name = original.m_name;
    }
    
    [UsedImplicitly] public readonly string Name;
}