using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacteristic
{
    public Action<float> OnValueUpdated;
    
    private float _baseValue;
    private float _additionalValue;

    public virtual float Value => _baseValue + _additionalValue;

    public BaseCharacteristic()
    {
        ResetValues();
    }
    
    public BaseCharacteristic(float value) : this()
    {
        _baseValue = value;
    }

    protected void ResetValues()
    {
        _baseValue = _additionalValue = 0;
    }

    public void AddValue(float value)
    {
        _additionalValue += value;
        UpdateInternal();
    }

    protected virtual void UpdateInternal()
    {
        OnValueUpdated?.Invoke(Value);
    }

    public override string ToString()
    {
        return $"{GetType()}: {_baseValue} + {_additionalValue} = {Value}";
    }
}
