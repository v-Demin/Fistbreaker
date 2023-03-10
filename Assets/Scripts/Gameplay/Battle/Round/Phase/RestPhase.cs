using DG.Tweening;

public class RestPhase : AbstractRoundPhase
{
    public override void StartPhase()
    {
        DOVirtual.DelayedCall(2f, EndPhase);
    }
}
