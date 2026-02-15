// 実行時に存在するカードの実体
public class CardInstance
{
    // 参照するカード定義
    public CardDefinition Definition { get; private set; }

    // 所有プレイヤーID
    public int OwnerPlayerId { get; private set; }

    // コンストラクタ
    public CardInstance(CardDefinition definition, int ownerPlayerId)
    {
        Definition = definition;
        OwnerPlayerId = ownerPlayerId;
    }
}
