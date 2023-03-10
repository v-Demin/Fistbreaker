using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ControlContainer : IDisposable
{
    [Inject] private readonly InputTaker _inputTaker;
    
    private List<ControlCombination> _combinations = new ();
    private bool isTakingInput_TODELETE = false;

    public ControlContainer Init(bool isTakingInput)
    {
        isTakingInput_TODELETE = isTakingInput;
        _inputTaker.OnKeyUpdate += OnKeyUpdated;
        return this;
    }

    public void Dispose()
    {
        _inputTaker.OnKeyUpdate -= OnKeyUpdated;
    }

    public void Register(ControlCombination controlCombination)
    {
        _combinations.Add(controlCombination);
    }
    
    public void Unregister(ControlCombination controlCombination)
    {
        _combinations.Remove(controlCombination);
    }

    private void OnKeyUpdated(List<InputKey> keyList)
    {
        if(isTakingInput_TODELETE == false) return;
        
        if(keyList.Count == 0) return;

        var combinationToCheck = new ControlCombination(keyList);

        FindEqualCombination(combinationToCheck)?.Execute(() => _inputTaker.ResetKeys());

        if (!IsAnyControlAccessable(combinationToCheck))
        {
            _inputTaker.ResetKeys();
        }
    }

    private bool IsAnyControlAccessable(ControlCombination controlCombination) =>
        _combinations.Any(pair => pair.IsAccessable(controlCombination));

    private ControlCombination FindEqualCombination(ControlCombination controlCombination) =>
        _combinations.FirstOrDefault(combo => combo.IsKeysEquals(controlCombination));
}
