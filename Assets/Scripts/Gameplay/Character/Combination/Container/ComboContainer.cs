using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ComboContainer : IDisposable
{
    [Inject] private readonly InputTaker _inputTaker;
    
    private List<Combination> _combinations = new ();
    private bool isTakingInput_TODELETE = false;

    public ComboContainer Init(bool isTakingInput)
    {
        isTakingInput_TODELETE = isTakingInput;
        _inputTaker.OnKeyUpdate += OnKeyUpdated;
        return this;
    }

    public void Dispose()
    {
        _inputTaker.OnKeyUpdate -= OnKeyUpdated;
    }

    public void Register(Combination combination)
    {
        _combinations.Add(combination);
    }
    
    public void Unregister(Combination combination)
    {
        _combinations.Remove(combination);
    }

    private void OnKeyUpdated(List<InputKey> keyList)
    {
        if(isTakingInput_TODELETE == false) return;
        
        if(keyList.Count == 0) return;

        var combinationToCheck = new Combination(keyList);

        FindEqualCombination(combinationToCheck)?.Execute(() => _inputTaker.ResetKeys());

        if (IsDownButtonPressed(combinationToCheck) || !IsAnyComboAccessable(combinationToCheck))
        {
            _inputTaker.ResetKeys();
        }
    }

    private bool IsDownButtonPressed(Combination combination) =>
        combination.IsContains(InputKey.Down) && combination.KeyCount >= 1;
    
    private bool IsAnyComboAccessable(Combination combination) =>
        _combinations.Any(pair => pair.IsAccessable(combination));

    private Combination FindEqualCombination(Combination combination) =>
        _combinations.FirstOrDefault(combo => combo.IsKeysEquals(combination));
}
