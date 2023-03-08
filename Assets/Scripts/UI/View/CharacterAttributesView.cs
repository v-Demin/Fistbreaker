using System;
using DG.Tweening;
using UnityEngine;

public class CharacterAttributesView : MonoBehaviour
{
    //[Todo]: нормальные зависимости
    [SerializeField] private Character _character;
    [SerializeField] private CharacterAttributeBar _healthBar;
    [SerializeField] private CharacterAttributeBar _manaBar;

    private void OnEnable()
    {
        DOVirtual.DelayedCall(0.01f, () =>
        {
            _character.Attributes.CurrentAttributes.OnCurrentAttributesChanged += attributes => UpdateBar();
            UpdateBar();
        });
    }

    private void OnDisable()
    {
        _character.Attributes.CurrentAttributes.OnCurrentAttributesChanged -= attributes => UpdateBar();
    }

    private void UpdateBar()
    {
        _healthBar.ShowInfo(_character.Attributes.CurrentAttributes.Health, _character.Attributes.MaxAttributes.Health);
        _manaBar.ShowInfo(_character.Attributes.CurrentAttributes.Mana, _character.Attributes.MaxAttributes.Mana);
    }
}
