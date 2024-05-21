using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class PickableModel : NameModel
{
    public PickableModel(Pickable original) : base(internalName: original.name, nameToken: original.m_overrideName)
    {
    }
}