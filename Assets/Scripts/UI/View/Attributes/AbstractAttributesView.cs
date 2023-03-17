using System;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;
using Zenject;

public abstract class AbstractAttributesView : MonoBehaviour
{
    protected abstract BattleSide SideToCheck { get; }
    [SerializeField] private CharacterAttributeBar _healthBar;
    [SerializeField] private CharacterAttributeBar _manaBar;
    private Character _lastCharacter;

    private void OnEnable()
    {
        DOVirtual.DelayedCall(0.01f, () =>
        {
            SideToCheck.CharacterChanges += character => OnCharacterChanges();
            OnCharacterChanges();
        });
    }

    private void OnCharacterChanges()
    {
        if(_lastCharacter != null) _lastCharacter.Attributes.CurrentAttributes.OnCurrentAttributesChanged -= attributes => UpdateBar(); 
        SideToCheck.CurrentBattleCharacter.Attributes.CurrentAttributes.OnCurrentAttributesChanged += attributes => UpdateBar();
        _lastCharacter = SideToCheck.CurrentBattleCharacter;
        UpdateBar();
    }

    private void UpdateBar()
    {
        _healthBar.ShowInfo(SideToCheck.CurrentBattleCharacter.Attributes.CurrentAttributes.Health, SideToCheck.CurrentBattleCharacter.Attributes.MaxAttributes.Health);
        _manaBar.ShowInfo(SideToCheck.CurrentBattleCharacter.Attributes.CurrentAttributes.Mana, SideToCheck.CurrentBattleCharacter.Attributes.MaxAttributes.Mana);
    }
}
