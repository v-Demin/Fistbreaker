using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycleController : MonoBehaviour
{
    public Action<int> OnRoundStarted;
    public Action<int> OnRoundEnded;
    private int _roundNumber;

    private void StartNextRound()
    {
        _roundNumber++;
        OnRoundStarted?.Invoke(_roundNumber);
    }
    
    private void EndRound()
    {
        OnRoundEnded?.Invoke(_roundNumber);
    }

    [SerializeField] private BattleSide _playerSide;
    [SerializeField] private BattleSide _enemySide;

    public Character GetEnemyFor(Character character)
    {
        if (_playerSide.Contains(character))
        {
            return _enemySide.CurrentBattleCharacter;
        }

        if (_enemySide.Contains(character))
        {
            return _playerSide.CurrentBattleCharacter;
        }

        throw new ArgumentException("Данный персонаж не состоит ни в одной стороне данный битвы");
    }
}
