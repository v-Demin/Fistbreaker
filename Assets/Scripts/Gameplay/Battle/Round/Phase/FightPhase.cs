using UnityEngine;
using Zenject;

public class FightPhase : AbstractRoundPhase
{
    [Inject] private readonly SPTimer _timer;
    [Inject] private readonly InputTaker _inputTaker;
    [Inject] private readonly BattleController _battleController;

    private BattleSide PlayerSide => _battleController.PlayerSide;
    private BattleSide EnemySide => _battleController.EnemySide;
    
    
    public override void StartPhase()
    {
        $"Фаза {GetType()} стартанула".Log(Color.cyan);
        _timer.StartTimer(PlayerSide.CurrentBattleCharacter.Attributes.CurrentAttributes.Stamina);
        _inputTaker.ChangeInputAvailability(true);

        _timer.OnTimerEnded += EndPhase;
        PlayerSide.OnAllCharactersDefeated += EndPhase;
        EnemySide.OnAllCharactersDefeated += EndPhase;
    }

    public override void EndPhase()
    {
        _timer.Stop();
        _inputTaker.ChangeInputAvailability(false);

        _timer.OnTimerEnded -= EndPhase;
        PlayerSide.OnAllCharactersDefeated -= EndPhase;
        EnemySide.OnAllCharactersDefeated -= EndPhase;
        
        base.EndPhase();
    }
}
