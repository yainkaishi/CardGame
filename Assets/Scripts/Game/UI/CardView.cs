using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void SetCard(CardDefinition card)
    {
        if (card == null)
        {
            nameText.text = "";
            descriptionText.text = "";
            return;
        }

        nameText.text = LocalizationManager.GetText(card.NameKey);
        descriptionText.text = LocalizationManager.GetText(card.DescriptionKey);
    }
}
