using System;
using UnityEngine;
using Zenject;

public class FightPhase : AbstractRoundPhase
{
    [Inject] private readonly SPTimer _timer;
    [Inject] private readonly InputTaker _inputTaker;
    [Inject] private readonly BattleController _battleController;

    public static Action FightPhaseStarted;
    public static Action FightPhaseEnded;

    private BattleSide PlayerSide => _battleController.PlayerSide;
    private BattleSide EnemySide => _battleController.EnemySide;
    
    
    public override void StartPhase()
    {
        $"Фаза {GetType()} стартанула".Log(Color.cyan);
        _timer.StartTimer(GameConstants.BASE_ROUND_DURATION);
        _inputTaker.ChangeInputAvailability(true);

        _timer.OnTimerEnded += EndPhase;
        PlayerSide.OnAllCharactersDefeated += EndPhase;
        EnemySide.OnAllCharactersDefeated += EndPhase;
        FightPhaseStarted?.Invoke();
    }

    public override void EndPhase()
    {
        _timer.Stop();
        _inputTaker.ChangeInputAvailability(false);

        _timer.OnTimerEnded -= EndPhase;
        PlayerSide.OnAllCharactersDefeated -= EndPhase;
        EnemySide.OnAllCharactersDefeated -= EndPhase;
        
        FightPhaseEnded?.Invoke();
        
        base.EndPhase();
    }
}
