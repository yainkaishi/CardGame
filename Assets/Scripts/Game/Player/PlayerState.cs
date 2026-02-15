using System.Collections.Generic;

// プレイヤーの状態を管理するクラス
public class PlayerState
{
    // プレイヤーID（1 or 2）
    public int PlayerId { get; private set; }

    // 手札
    public List<CardInstance> Hand { get; private set; }

    // 山札
    public List<CardInstance> Deck { get; private set; }

    // 墓地
    public List<CardInstance> Graveyard { get; private set; }

    // 現在セットしているカード（単数想定）
    public CardInstance SetCard { get; private set; }

    // コンストラクタ
    public PlayerState(int playerId)
    {
        PlayerId = playerId;
        Hand = new List<CardInstance>();
        Deck = new List<CardInstance>();
        Graveyard = new List<CardInstance>();
        SetCard = null;
    }

    // カードをセットする
    public void SetCardFromHand(CardInstance card)
    {
        if (Hand.Contains(card))
        {
            Hand.Remove(card);
            SetCard = card;
        }
    }

    // セットカードを墓地へ送る
    public void MoveSetCardToGraveyard()
    {
        if (SetCard != null)
        {
            Graveyard.Add(SetCard);
            SetCard = null;
        }
    }
}
