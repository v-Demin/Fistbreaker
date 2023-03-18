using System;
using UnityEngine;
using Zenject;

public class FightPhase : AbstractRoundPhase
{
    [Inject] private readonly SPTimer _timer;
    [Inject] private readonly InputTaker _inputTaker;
    [Inject] private readonly RhythmGameplayController _rhythmGameplay;

    public static Action FightPhaseStarted;
    public static Action FightPhaseEnded;
    
    
    public override void StartPhase()
    {
        $"Фаза {GetType()} стартанула".Log(Color.cyan);
        _timer.StartTimer(GameConstants.BASE_ROUND_DURATION);
        _inputTaker.ChangeInputAvailability(true);
        _rhythmGameplay.StartGameplay();

        _timer.OnTimerEnded += EndPhase;
        FightPhaseStarted?.Invoke();
    }

    public override void EndPhase()
    {
        _timer.Stop();
        _inputTaker.ChangeInputAvailability(false);
        _rhythmGameplay.EndGameplay();

        _timer.OnTimerEnded -= EndPhase;
        
        FightPhaseEnded?.Invoke();
        
        base.EndPhase();
    }
}
