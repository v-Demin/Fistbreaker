using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

public class BattleSide
{
    public event Action AllCharactersDefeated;
    public event Action<Character> CharacterDefeated;
    public event Action<Character> CharacterChanges;
    
    private List<Character> _characters = new ();
        
    public Character CurrentBattleCharacter => _characters.FirstOrDefault();
    public bool Contains(Character character) => _characters.Contains(character);
    
    public BattleSide(List<Character> characters)
    {
        _characters = characters;
        _characters.ForEach(character => character.Init());

        EnableCurrentCharacter();

        _characters.ForEach(character =>
            character.Attributes.CurrentAttributes.OnHealthOver += () => CharacterDefeated?.Invoke(character));
        
        Round.OnRoundEnd += () =>
        {
            SetNextCharacterAsCurrent();
            DefeatCharacters();
        };
    }
    
    private void DefeatCharacters()
    {
        _characters.RemoveAll(character => character.Attributes.CurrentAttributes.Health <= 0);
        
        if (_characters.IsEmpty())
        {
            AllCharactersDefeated?.Invoke();
        }
    }

    private void EnableCurrentCharacter()
    {
        if (_characters.IsEmpty()) return;

        _characters.ForEach(character => character.Disable());
        CurrentBattleCharacter.Enable();
    }

    private void SetNextCharacterAsCurrent()
    {
        if (_characters.IsEmpty()) return;

        _characters.ShiftLeft(1);
        CharacterChanges?.Invoke(CurrentBattleCharacter);
        EnableCurrentCharacter();
    }
}
