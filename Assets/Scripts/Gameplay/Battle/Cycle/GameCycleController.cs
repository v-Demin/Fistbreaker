using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCycleController : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    [Inject] private readonly BattleController _battle;
    
    private int _roundNumber;
    private Cycle _cycle;

    private void Start()
    {
        StartNewGameCycle();
        _battle.EnemySideDefeated += OnPlayerWin;
        _battle.PlayerSideDefeated += OnPlayerLose;
    }

    private void StartNewGameCycle()
    {
        _cycle = _container.Instantiate<Cycle>();
        _cycle.Enable();
    }

    private void OnPlayerWin()
    {
        $"Пабеда".Log(new Color(0.5f, 0.4f, 0.1f));
        EndGameCycle();
    }

    private void OnPlayerLose()
    {
        $"Не пабеда".Log(new Color(0.5f, 0.4f, 0.1f));
        EndGameCycle();
    }

    private void EndGameCycle()
    {
        _cycle.Disable();
    }
}
