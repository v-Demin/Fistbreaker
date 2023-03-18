using DG.Tweening;
using Zenject;

public class RestPhase : AbstractRoundPhase
{
    [Inject] private readonly InputTaker _inputTaker;

    public override void StartPhase()
    {
        _inputTaker.ChangeInputAvailability(false);
        DOVirtual.DelayedCall(2f, EndPhase);
    }
}
