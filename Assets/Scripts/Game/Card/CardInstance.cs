// カード効果の種類
public enum CardEffectType
{
    None,               // 効果なし
    DealDamage,         // ダメージを与える
    WinGame,            // 特殊勝利
    LoseGame,           // 特殊敗北
    GainInitiative,     // イニシアチブ獲得
    LoseInitiative      // イニシアチブ喪失
}
