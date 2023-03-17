using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ControlContainer: IEnablable
{
    [Inject] private readonly InputTaker _inputTaker;
    
    private List<ControlCombination> _combinations = new ();

    public void Enable()
    {
        _inputTaker.KeyUpdate += OnKeyUpdated;
    }

    public void Disable()
    {
        _inputTaker.KeyUpdate -= OnKeyUpdated;
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
