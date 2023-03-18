using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Zenject;

public class Round : IEnablable
{
    [Inject] private readonly DiContainer _container;

    public static Action OnRoundEnd;
    
    private List<AbstractRoundPhase> _phases = new ();

    public Round Init()
    {
        _phases.Add(_container.Instantiate<FightPhase>());
        _phases.Add(_container.Instantiate<RestPhase>());
        return this;
    }
    
    public void Enable()
    {
        StartNextPhase();
    }

    public void Disable()
    {
        _phases.ForEach(phase => phase.EndPhase());
        _phases.Clear();
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
