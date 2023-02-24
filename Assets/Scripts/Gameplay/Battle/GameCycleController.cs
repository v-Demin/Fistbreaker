using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycleController : MonoBehaviour
{
    public Action<int> OnRoundUpdated;
    private int _round;

    private void StartNextRound()
    {
        _round++;
        OnRoundUpdated?.Invoke(_round);
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
