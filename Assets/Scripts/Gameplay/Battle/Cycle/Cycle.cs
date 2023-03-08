using Zenject;

public class Cycle
{
    [Inject] private readonly DiContainer _container;
    
    public int RoundNumber { get; private set; }
    
    private Round _currentRound;
    
    public void StartNewRound()
    {
        _currentRound = _container.Instantiate<Round>().Init();
        _currentRound.OnRoundEnd += OnRoundEnded;
        _currentRound.StartRound();
    }

    public void OnRoundEnded()
    {
        RoundNumber++;
        _currentRound.OnRoundEnd -= OnRoundEnded;
        StartNewRound();
    }
}
