using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Zenject;

public class Round
{
    [Inject] private readonly DiContainer _container;

    public Action OnRoundEnd;
    
    private List<AbstractRoundPhase> _phases = new ();

    public Round Init()
    {
        _phases.Add(_container.Instantiate<PreparationPhase>());
        _phases.Add(_container.Instantiate<ExecutionPhase>());
        return this;
    }

    public void StartRound()
    {
        StartNextPhase();
    }
    
    private void StartNextPhase()
    {
        if (_phases.IsEmpty())
        {
            EndRound();
        }
        else
        {
            var nextPhase = _phases.FirstOrDefault();
            _phases.Remove(nextPhase);
            nextPhase.OnEndPhase += StartNextPhase;
            nextPhase.StartPhase();
        }
    }

    private void EndRound()
    {
        OnRoundEnd?.Invoke();
    }
}
