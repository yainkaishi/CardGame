using UnityEngine;

// ゲームの流れを簡易的に確認するためのテスト用クラス
public class GameSimulator : MonoBehaviour
{
    private GameState gameState;

    void Start()
    {
        // ゲーム状態を生成
        gameState = new GameState();

        Debug.Log("=== ゲーム開始 ===");
        Debug.Log($"ターン: {gameState.Turn}");
        Debug.Log($"初期フェーズ: {gameState.CurrentPhase}");

        // 1ターン分フェーズを回す
        SimulateOneTurn();
    }

    private void SimulateOneTurn()
    {
        // Endフェーズになるまで回す
        while (gameState.CurrentPhase != GamePhase.End)
        {
            gameState.NextPhase();
            Debug.Log($"フェーズ遷移: {gameState.CurrentPhase}");
        }

        // Endフェーズも進める
        gameState.NextPhase();

        Debug.Log("=== ターン終了 ===");
        Debug.Log($"現在ターン: {gameState.Turn}");
        Debug.Log($"現在フェーズ: {gameState.CurrentPhase}");
    }
}
