using System;

public class Combo
{
    public Action<int> ComboUpdate;
    
    public int CurrentCombo => _maxComboLastRound + _comboCurrentRound;
    private int _maxComboLastRound;
    private int _comboCurrentRound;
    private int _maxComboCurrentRound;

    public Combo()
    {
        Round.OnRoundEnd += OnRoundEnd;
    }

    public void AddOne()
    {
        _comboCurrentRound++;
        if (_maxComboCurrentRound < _comboCurrentRound) _maxComboCurrentRound = _comboCurrentRound;
        ComboUpdate?.Invoke(CurrentCombo);
    }

    public void ResetCurrent()
    {
        _comboCurrentRound = 0;
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
