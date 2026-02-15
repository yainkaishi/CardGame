// ゲーム全体の状態を管理するクラス
public class GameState
{
    // 現在のターン数
    public int Turn { get; private set; }

    // 現在のフェーズ
    public GamePhase CurrentPhase { get; private set; }

    // イニシアチブ保持者
    public InitiativePlayer Initiative { get; private set; }

    // プレイヤーHP
    public int PlayerAHP { get; private set; }
    public int PlayerBHP { get; private set; }

    // 勝敗状態
    public GameResult Result { get; private set; }

    public GameState()
    {
        Turn = 1;
        CurrentPhase = GamePhase.Setting;
        Initiative = InitiativePlayer.Player1;

        PlayerAHP = 5;
        PlayerBHP = 5;

        Result = GameResult.Playing;
    }

    // フェーズを進める
    public void NextPhase()
    {
        switch (CurrentPhase)
        {
            case GamePhase.Setting:
                CurrentPhase = GamePhase.SetComplete;
                break;

            case GamePhase.SetComplete:
                CurrentPhase = GamePhase.Open;
                break;

            case GamePhase.Open:
                CurrentPhase = GamePhase.Resolve;
                break;

            case GamePhase.Resolve:
                ExecuteResolve();
                CurrentPhase = GamePhase.End;
                break;

            case GamePhase.End:
                Turn++;
                ChangeInitiative();
                CurrentPhase = GamePhase.Setting;
                break;
        }
    }

    // Resolve処理（仮ルール）
    private void ExecuteResolve()
    {
        if (Initiative == InitiativePlayer.Player1)
        {
            PlayerBHP--;
        }
        else
        {
            PlayerAHP--;
        }

        CheckGameOver();
    }

    // 勝敗判定
    private void CheckGameOver()
    {
        if (PlayerAHP <= 0)
            Result = GameResult.Player2Win;

        if (PlayerBHP <= 0)
            Result = GameResult.Player1Win;
    }

    // イニシアチブ切り替え
    private void ChangeInitiative()
    {
        Initiative = Initiative == InitiativePlayer.Player1
            ? InitiativePlayer.Player2
            : InitiativePlayer.Player1;
    }
}
