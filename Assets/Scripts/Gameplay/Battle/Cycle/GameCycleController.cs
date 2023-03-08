using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCycleController : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    
    private int _roundNumber;
    private Cycle _cycle;

    private void Start()
    {
        StartNewGameCycle();
    }

    private void StartNewGameCycle()
    {
        _cycle = _container.Instantiate<Cycle>();
        _cycle.StartNewRound();
    }
}
