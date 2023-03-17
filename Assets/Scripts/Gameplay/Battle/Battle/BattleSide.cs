using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class BattleSide
{
    public Action AllCharactersDefeated;
    public Action<Character> CharacterChanges;
    
    //[Todo]: учёт побеждённых персонажей
    public Character CurrentBattleCharacter => _characters.FirstOrDefault();
    public bool Contains(Character character) => _characters.Contains(character);
    
    [SerializeField] private List<Character> _characters;
    
    public BattleSide(List<Character> characters)
    {
        _characters = characters;
        _characters.ForEach(character => character.Init());
        EnableCurrentCharacter();
        
        Round.OnRoundEnd += SetNextCharacterAsCurrent;
        CharacterChanges += character => EnableCurrentCharacter();
    }

    private void EnableCurrentCharacter()
    {
        _characters.ForEach(character => character.Disable());
        CurrentBattleCharacter.Enable();
    }

    private void SetNextCharacterAsCurrent()
    {
        if (_characters.Count > 1)
        {
            _characters.ShiftLeft(1);
            CharacterChanges?.Invoke(CurrentBattleCharacter);
        }
    }
}
