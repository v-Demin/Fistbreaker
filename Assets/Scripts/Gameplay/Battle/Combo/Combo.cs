using System;
using UnityEngine;

public class Combo
{
    public Action<int> ComboUpdate;
    
    public int CurrentCombo => _maxComboLastRound + _comboCurrentRound;
    private int _maxComboLastRound;
    private int _comboCurrentRound;
    private int _maxComboCurrentRound;

    public void AddOne()
    {
        _comboCurrentRound++;
        if (_maxComboCurrentRound < _comboCurrentRound) _maxComboCurrentRound = _comboCurrentRound;
        ComboUpdate?.Invoke(CurrentCombo);
    }

    public void ResetToLastMax()
    {
        _comboCurrentRound = _maxComboLastRound;
        ComboUpdate?.Invoke(CurrentCombo);
    }

    public void OnRoundEnd()
    {
        _maxComboLastRound += _maxComboCurrentRound;
        _comboCurrentRound = 0;
        _maxComboCurrentRound = 0;
        ComboUpdate?.Invoke(CurrentCombo);
    }
}
