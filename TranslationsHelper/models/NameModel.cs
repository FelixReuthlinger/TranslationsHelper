using System.Collections.Generic;
using JetBrains.Annotations;
using Jotunn;

namespace TranslationsHelper.models;

public class NameModel : Translatable
{
    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string TranslationNameToken;

    public NameModel(string internalName, string nameToken)
    {
        Name = internalName;
        TranslationNameToken = nameToken;
    }

    public NameModel(Character fromCharacter) : this(fromCharacter.name, fromCharacter.m_name)
    {
    }

    public NameModel(HoverText fromHoverText) : this(internalName: fromHoverText.name, nameToken: fromHoverText.m_text)
    {
    }

    public NameModel(MineRock fromMineRock) : this(internalName: fromMineRock.name, nameToken: fromMineRock.m_name)
    {
    }
    
    public NameModel(MineRock5 fromMineRock5) : this(internalName: fromMineRock5.name, nameToken: fromMineRock5.m_name)
    {
    }
    
    public NameModel(ItemStand fromItemStand) : this(internalName: fromItemStand.name, nameToken: fromItemStand.m_name)
    {
    }
    
    public NameModel(Ladder fromLadder) : this(internalName: fromLadder.name, nameToken: fromLadder.m_name)
    {
    }
    
    public NameModel(Plant fromPlant) : this(internalName: fromPlant.name, nameToken: fromPlant.m_name)
    {
    }
    
    public NameModel(Chair fromChair) : this(internalName: fromChair.name, nameToken: fromChair.m_name)
    {
    }

    public override List<string> Translate()
    {
        return new List<string> { TranslateTokenToPair(TranslationNameToken) };
    }
}