using System.Collections.Generic;
using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class CommonModel : NameModel
{
    public CommonModel(ItemDrop fromItemDrop) : base(fromItemDrop.name, fromItemDrop.m_itemData.m_shared.m_name)
    {
        TranslationDescriptionToken = fromItemDrop.m_itemData.m_shared.m_description;
    }

    public CommonModel(Piece fromPiece) : base(fromPiece.name, fromPiece.m_name)
    {
        TranslationDescriptionToken = fromPiece.m_description;
    }

    [UsedImplicitly] public readonly string TranslationDescriptionToken;

    public override List<string> Translate()
    {
        return new List<string>
        {
            TranslateTokenToPair(TranslationNameToken), 
            TranslateTokenToPair(TranslationDescriptionToken)
        };
    }
}