using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerAHPText;
    public TextMeshProUGUI playerBHPText;
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI resultText;

    private GameState gameState;

    void Start()
    {
        gameState = new GameState();
        UpdateUI();
    }

    public void NextPhase()
    {
        if (gameState.Result != GameResult.Playing)
            return;

        gameState.NextPhase();
        UpdateUI();
    }

    void UpdateUI()
    {
        playerAHPText.text = "Player A HP: " + gameState.PlayerAHP;
        playerBHPText.text = "Player B HP: " + gameState.PlayerBHP;
        turnText.text = "Turn: " + gameState.Turn;
        phaseText.text = "Phase: " + gameState.CurrentPhase;
        resultText.text = "Result: " + gameState.Result;
    }
}
