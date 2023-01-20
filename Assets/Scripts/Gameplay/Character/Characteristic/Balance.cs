using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Balance : AbstractCharacteristic
{
    private const float BASE_POWER_BONUS = 1.2f; 

    private float _powerBonus = BASE_POWER_BONUS;
    private float _additionalPowerBonus = 0f;

    public float AdditionalPower => _powerBonus * Value; 
    public override float Value => Mathf.Min(SumList(_bodyCharacteristics), SumList(_mindCharacteristics)) /
                                   Mathf.Max(SumList(_bodyCharacteristics), SumList(_mindCharacteristics));

    private float SumList(List<AbstractCharacteristic> list) => list.Sum(c => c.Value);

    private readonly List<AbstractCharacteristic> _characteristics;
    private readonly List<AbstractCharacteristic> _bodyCharacteristics;
    private readonly List<AbstractCharacteristic> _mindCharacteristics;
    
    public Balance(ref List<AbstractCharacteristic> characteristics)
    {
        _characteristics = characteristics;
        _bodyCharacteristics = _characteristics.FindAll(characteristic => characteristic is AbstractBodyCharacteristic);
        _mindCharacteristics = _characteristics.FindAll(characteristic => characteristic is AbstractMindCharacteristic);
    }
}
