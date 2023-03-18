using Zenject;

public class Cycle : IEnablable
{
    [Inject] private readonly DiContainer _container;
    
    private Round _currentRound;
    
    private void StartNewRound()
    {
        _currentRound = _container.Instantiate<Round>().Init();
        _currentRound.Enable();
    }

    public void Enable()
    {
        Round.OnRoundEnd += OnRoundEnded;
        StartNewRound();
    }

    public void Disable()
    {
        Round.OnRoundEnd -= OnRoundEnded;
        _currentRound.Disable();
    }
    
    private void OnRoundEnded()
    {
        StartNewRound();
    }
}
