// カードのマスターデータ
public class CardDefinition
{
    // カードID
    public int Id { get; private set; }

    // カード名
    public string Name { get; private set; }

    // 効果の種類
    public CardEffectType EffectType { get; private set; }

    // 効果の数値（ダメージ量など）
    public int EffectValue { get; private set; }

    // コンストラクタ
    public CardDefinition(int id, string name, CardEffectType effectType, int effectValue)
    {
        Id = id;
        Name = name;
        EffectType = effectType;
        EffectValue = effectValue;
    }
}
