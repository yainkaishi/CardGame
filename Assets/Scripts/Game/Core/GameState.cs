using UnityEngine;

public class GameState
{
    public int Turn { get; private set; }
    public GamePhase CurrentPhase { get; private set; }
    public InitiativePlayer Initiative { get; private set; }

    public int PlayerAHP { get; private set; }
    public int PlayerBHP { get; private set; }

    public GameResult Result { get; private set; }

    public CardInstance PlayerASetCard { get; private set; }
    public CardInstance PlayerBSetCard { get; private set; }

    private CardDefinition attackCard;
    private CardDefinition guardCard;

    private bool playerASelected;
    private bool playerBSelected;

    public GameState()
    {
        Turn = 1;
        CurrentPhase = GamePhase.Setting;
        Initiative = InitiativePlayer.Player1;

        PlayerAHP = 5;
        PlayerBHP = 5;

        Result = GameResult.Playing;

        attackCard = new CardDefinition(1, "CARD_1_NAME", "CARD_1_DESC", CardEffectType.DealDamage, 1);
        guardCard  = new CardDefinition(2, "CARD_2_NAME", "CARD_2_DESC", CardEffectType.Guard, 0);

        playerASelected = false;
        playerBSelected = false;
    }

    // ===== 選択 =====

    public void SelectPlayerAAttack()
    {
        if (CurrentPhase != GamePhase.Setting) return;

        PlayerASetCard = new CardInstance(attackCard);
        playerASelected = true;
        CheckBothSelected();
    }

    public void SelectPlayerAGuard()
    {
        if (CurrentPhase != GamePhase.Setting) return;

        PlayerASetCard = new CardInstance(guardCard);
        playerASelected = true;
        CheckBothSelected();
    }

    public void SelectPlayerBAttack()
    {
        if (CurrentPhase != GamePhase.Setting) return;

        PlayerBSetCard = new CardInstance(attackCard);
        playerBSelected = true;
        CheckBothSelected();
    }

    public void SelectPlayerBGuard()
    {
        if (CurrentPhase != GamePhase.Setting) return;

        PlayerBSetCard = new CardInstance(guardCard);
        playerBSelected = true;
        CheckBothSelected();
    }

    private void CheckBothSelected()
    {
        if (playerASelected && playerBSelected)
        {
            CurrentPhase = GamePhase.SetComplete;
        }
    }

    // ===== フェーズ進行 =====

    public void NextPhase()
    {
        switch (CurrentPhase)
        {
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

                PlayerASetCard = null;
                PlayerBSetCard = null;
                playerASelected = false;
                playerBSelected = false;

                CurrentPhase = GamePhase.Setting;
                break;
        }
    }

    // ===== イニシアチブ順解決 =====

    private void ExecuteResolve()
    {
        Debug.Log("Resolve実行");

        if (Initiative == InitiativePlayer.Player1)
        {
            ResolvePlayerA();
            if (Result == GameResult.Playing)
                ResolvePlayerB();
        }
        else
        {
            ResolvePlayerB();
            if (Result == GameResult.Playing)
                ResolvePlayerA();
        }

        CheckGameOver();
    }

    private void ResolvePlayerA()
    {
        if (PlayerASetCard == null) return;

        bool aIsAttack = PlayerASetCard.Definition.EffectType == CardEffectType.DealDamage;
        bool bIsGuard = PlayerBSetCard?.Definition.EffectType == CardEffectType.Guard;

        if (aIsAttack && !bIsGuard)
        {
            PlayerBHP -= 1;
        }
    }

    private void ResolvePlayerB()
    {
        if (PlayerBSetCard == null) return;

        bool bIsAttack = PlayerBSetCard.Definition.EffectType == CardEffectType.DealDamage;
        bool aIsGuard = PlayerASetCard?.Definition.EffectType == CardEffectType.Guard;

        if (bIsAttack && !aIsGuard)
        {
            PlayerAHP -= 1;
        }
    }

    private void CheckGameOver()
    {
        if (PlayerAHP <= 0)
            Result = GameResult.Player2Win;

        if (PlayerBHP <= 0)
            Result = GameResult.Player1Win;
    }

    private void ChangeInitiative()
    {
        Initiative = Initiative == InitiativePlayer.Player1
            ? InitiativePlayer.Player2
            : InitiativePlayer.Player1;
    }
}
