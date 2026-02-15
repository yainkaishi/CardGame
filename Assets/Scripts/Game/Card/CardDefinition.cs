// カード定義データ
public class CardDefinition
{
    public int Id { get; private set; }

    // 表示名キー（例: CARD_ATTACK）
    public string NameKey { get; private set; }

    // 説明文キー（例: CARD_ATTACK_DESC）
    public string DescriptionKey { get; private set; }

    public CardEffectType EffectType { get; private set; }
    public int EffectValue { get; private set; }

    public CardDefinition(
        int id,
        string nameKey,
        string descriptionKey,
        CardEffectType effectType,
        int effectValue)
    {
        Id = id;
        NameKey = nameKey;
        DescriptionKey = descriptionKey;
        EffectType = effectType;
        EffectValue = effectValue;
    }
}
