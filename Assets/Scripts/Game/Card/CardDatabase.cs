using System.Collections.Generic;

public static class CardDatabase
{
    private static Dictionary<int, CardDefinition> cards;

    static CardDatabase()
    {
        cards = new Dictionary<int, CardDefinition>();

        for (int i = 1; i <= 11; i++)
        {
            AddCard(new CardDefinition(
                i,
                $"CARD_{i}_NAME",
                $"CARD_{i}_DESC",
                CardEffectType.None,
                0
            ));
        }
    }

    private static void AddCard(CardDefinition card)
    {
        cards.Add(card.Id, card);
    }

    public static CardDefinition GetCard(int id)
    {
        return cards[id];
    }

    public static List<CardDefinition> GetAllCards()
    {
        return new List<CardDefinition>(cards.Values);
    }
}
