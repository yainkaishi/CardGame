// 実行時カード
public class CardInstance
{
    public CardDefinition Definition { get; private set; }

    public CardInstance(CardDefinition definition)
    {
        Definition = definition;
    }
}
