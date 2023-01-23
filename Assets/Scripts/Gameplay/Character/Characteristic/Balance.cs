using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Balance : BaseCharacteristic
{
    public override float Value => Mathf.Min(SumList(_bodyCharacteristics), SumList(_mindCharacteristics)) /
                                   Mathf.Max(SumList(_bodyCharacteristics), SumList(_mindCharacteristics));

    private float SumList<T>(List<T> list) where T : BaseCharacteristic => list.Sum(c => c.Value);

    private readonly List<BaseBodyCharacteristic> _bodyCharacteristics;
    private readonly List<BaseSpiritCharacteristic> _mindCharacteristics;
    
    public Balance(ref List<BaseCharacteristic> characteristics)
    {
        _bodyCharacteristics = characteristics.OfType<BaseBodyCharacteristic>().ToList();
        _mindCharacteristics = characteristics.OfType<BaseSpiritCharacteristic>().ToList();
    }
}
