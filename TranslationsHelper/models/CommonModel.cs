using JetBrains.Annotations;

namespace TranslationsHelper.models;

public class CommonModel
{
    public CommonModel(ItemDrop fromItemDrop)
    {
        Name = fromItemDrop.name;
        TranslationNameToken = fromItemDrop.m_itemData.m_shared.m_name;
        TranslationDescriptionToken = fromItemDrop.m_itemData.m_shared.m_description;
        TranslatedName = Localization.instance.Localize(TranslationNameToken);
        TranslatedDescription = Localization.instance.Localize(TranslationDescriptionToken);
    }

    public CommonModel(Piece fromPiece)
    {
        Name = fromPiece.name;
        TranslationNameToken = fromPiece.m_name;
        TranslationDescriptionToken = fromPiece.m_description;
        TranslatedName = Localization.instance.Localize(TranslationNameToken);
        TranslatedDescription = Localization.instance.Localize(TranslationDescriptionToken);
    }

    [UsedImplicitly] public readonly string Name;
    [UsedImplicitly] public readonly string TranslationNameToken;
    [UsedImplicitly] public readonly string TranslationDescriptionToken;
    [UsedImplicitly] public readonly string TranslatedName;
    [UsedImplicitly] public readonly string TranslatedDescription;
}