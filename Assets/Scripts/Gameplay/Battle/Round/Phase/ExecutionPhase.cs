using DG.Tweening;

public class ExecutionPhase : AbstractRoundPhase
{
    public override void StartPhase()
    {
        DOVirtual.DelayedCall(2f, EndPhase);
    }
}
