using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI playerAHPText;
    public TextMeshProUGUI playerBHPText;
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI resultText;

    [Header("Card Views")]
    public CardView playerACardView;
    public CardView playerBCardView;

    private GameState gameState;

    void Start()
    {
        gameState = new GameState();
        UpdateUI();
    }

    // ===== プレイヤー入力 =====

    public void OnPlayerAAttack()
    {
        gameState.SelectPlayerAAttack();
        UpdateUI();
    }

    public void OnPlayerAGuard()
    {
        gameState.SelectPlayerAGuard();
        UpdateUI();
    }

    public void OnPlayerBAttack()
    {
        gameState.SelectPlayerBAttack();
        UpdateUI();
    }

    public void OnPlayerBGuard()
    {
        gameState.SelectPlayerBGuard();
        UpdateUI();
    }

    public void OnNextPhase()
    {
        if (gameState.Result != GameResult.Playing)
            return;

        gameState.NextPhase();
        UpdateUI();
    }

    // ===== UI更新 =====

    private void UpdateUI()
    {
        playerAHPText.text = $"Player A HP: {gameState.PlayerAHP}";
        playerBHPText.text = $"Player B HP: {gameState.PlayerBHP}";
        turnText.text = $"Turn: {gameState.Turn}";
        phaseText.text = $"Phase: {gameState.CurrentPhase}";
        resultText.text = $"Result: {gameState.Result}";

        playerACardView.SetCard(gameState.PlayerASetCard?.Definition);
        playerBCardView.SetCard(gameState.PlayerBSetCard?.Definition);
    }
}
