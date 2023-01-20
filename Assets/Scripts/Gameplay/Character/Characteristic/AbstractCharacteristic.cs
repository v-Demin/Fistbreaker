using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacteristic
{
    private float _value;

    public virtual float Value => _value;

    protected AbstractCharacteristic()
    {
        _value = Random.Range(0, 100);
    }

    public override string ToString()
    {
        return $"{GetType()}: Value = {Value}";
    }
}
