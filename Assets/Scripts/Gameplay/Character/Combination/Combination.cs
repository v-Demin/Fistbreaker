using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combination
{
    public Action OnCombinationExecuted;
    
    private List<InputKey> _keys;

    public Combination(List<InputKey> keys)
    {
        _keys = keys;
    }

    public void Execute(Action action)
    {
        OnCombinationExecuted?.Invoke();
        action?.Invoke();
    }

    public bool IsAccessable(Combination combination) =>  _keys.GetRange(0, combination._keys.Count).SequenceEqual(combination._keys);
    public bool IsKeysEquals(Combination combination) => _keys.SequenceEqual(combination._keys);
    public bool IsContains(InputKey key) => _keys.Contains(key);
    public int KeyCount => _keys.Count;

    public override string ToString()
    {
        return "Combination: " + _keys
            .Select(k => k.ToString())
            .Aggregate((cur, next) => cur + ", " + next);
    }
}
