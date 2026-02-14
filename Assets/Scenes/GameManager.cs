using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerAHPText;
    public TextMeshProUGUI playerBHPText;
    public TextMeshProUGUI turnText;

    private int playerAHP = 10;
    private int playerBHP = 10;
    private int turn = 1;

    void Start()
    {
        UpdateUI();
    }

    public void NextTurn()
    {
        Debug.Log("Button Pressed");
        turn++;
        UpdateUI();
    }

    void UpdateUI()
    {
        playerAHPText.text = "Player A HP: " + playerAHP;
        playerBHPText.text = "Player B HP: " + playerBHP;
        turnText.text = "Turn: " + turn;
    }
}
