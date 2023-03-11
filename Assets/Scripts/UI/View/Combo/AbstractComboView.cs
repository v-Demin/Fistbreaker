using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public abstract class AbstractComboView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    protected abstract Combo ComboToCheck { get; }

    private void Start()
    {
        DOVirtual.DelayedCall(0.01f, () =>
        {
            ComboToCheck.ComboUpdate += UpdateText;
            UpdateText(ComboToCheck.CurrentCombo);
        });
    }

    private void UpdateText(int comboNumber)
    {
        _text.text = $"x{comboNumber}";
    }
}
