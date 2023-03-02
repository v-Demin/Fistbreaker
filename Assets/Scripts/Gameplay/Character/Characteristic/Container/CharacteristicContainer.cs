using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CharacteristicContainer
{
   
    private List<BaseCharacteristic> _characteristics;

    private Type GetType(CharacteristicType type) => CharacteristicHelp.FromEnum(type);
    
    public BaseCharacteristic GetCharacteristic(CharacteristicType type) =>
        _characteristics.FirstOrDefault(c => c.GetType() == GetType(type));

    public void AddCharacteristic(CharacteristicType type, float addValue) =>
        GetCharacteristic(type).AddValue(addValue);

    #region Technical

    public CharacteristicContainer()
    {
        _characteristics = new List<BaseCharacteristic>()
        {
            new Strength(), new Agility(), new Endurance(),
            new Intelligence(), new Perception(), new Willpower()
        };
        _characteristics.Add(new Balance(ref _characteristics));
    }
    
    public CharacteristicContainer(List<BaseCharacteristic> values)
    {
        _characteristics = new List<BaseCharacteristic>(values);
        _characteristics.Add(new Balance(ref _characteristics));
    }

    public override string ToString()
    {
        return _characteristics
            .Select(c => c.ToString())
            .Aggregate((current, next) => current + '\n' + next);
    }

    #endregion
}
