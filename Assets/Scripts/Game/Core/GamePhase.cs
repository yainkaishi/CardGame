// ゲームの進行フェーズ
public enum GamePhase
{
    None,               // 未開始
    DealCards,          // カード配布フェーズ
    SelectAbility,      // 能力選択フェーズ
    Setting,            // カードセット中
    SetComplete,        // カードセット完了
    Open,               // 公開フェーズ
    Resolve,            // 効果解決フェーズ
    End                 // 終了処理フェーズ
}
