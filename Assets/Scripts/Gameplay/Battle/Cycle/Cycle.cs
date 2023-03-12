using Zenject;

public class Cycle
{
    [Inject] private readonly DiContainer _container;
    
    private Round _currentRound;
    
    public void StartNewRound()
    {
        _currentRound = _container.Instantiate<Round>().Init();
        Round.OnRoundEnd += OnRoundEnded;
        _currentRound.StartRound();
    }

    public void OnRoundEnded()
    {
        Round.OnRoundEnd -= OnRoundEnded;
        StartNewRound();
    }
}
