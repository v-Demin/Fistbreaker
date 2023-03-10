using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlCombination
{
    public Action OnCombinationExecuted;
    
    private List<InputKey> _keys;

    public ControlCombination(List<InputKey> keys)
    {
        _keys = keys;
    }

    public void Execute(Action action)
    {
        OnCombinationExecuted?.Invoke();
        action?.Invoke();
    }

    public bool IsAccessable(ControlCombination controlCombination) =>  _keys.GetRange(0, controlCombination._keys.Count).SequenceEqual(controlCombination._keys);
    public bool IsKeysEquals(ControlCombination controlCombination) => _keys.SequenceEqual(controlCombination._keys);
    public bool IsContains(InputKey key) => _keys.Contains(key);
    public int KeyCount => _keys.Count;

    public override string ToString()
    {
        return "Combination: " + _keys
            .Select(k => k.ToString())
            .Aggregate((cur, next) => cur + ", " + next);
    }
}
