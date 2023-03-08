using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[System.Serializable]
public class BattleSide
{
    [Inject] private readonly GameCycleController _cycleController;

    public Action OnAllCharactersDefeated;
    
    //[Todo]: учёт побеждённых персонажей
    public Character CurrentBattleCharacter => _characters.FirstOrDefault();
    public bool Contains(Character character) => _characters.Contains(character);
    
    [SerializeField] private List<Character> _characters;
    
    public BattleSide(List<Character> characters)
    {
        _characters = characters;
        //_cycleController.OnRoundEnded += i => SetNextCharacterAsCurrent();
    }

    private void SetNextCharacterAsCurrent()
    {
        if (_characters.Count > 1)
        {
            _characters.ShiftLeft(1);
        }
    }
}
