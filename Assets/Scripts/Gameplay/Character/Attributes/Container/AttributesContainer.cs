using System;
using UnityEngine;

public class AttributesContainer
{
    private readonly CharacteristicContainer _characteristics;




    //[Todo:] формулы
    public float DamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float EffectModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float CritDamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float BaseCritChance(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float DefendModifyer => _characteristics.GetCharacteristic(CharacteristicType.Balance).Value;
    public float PowerModifyer => _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value;

    public Attributes CurrentAttributes { get; private set; }
    public MaxAttributes MaxAttributes { get; private set; }

    public AttributesContainer(AttributesDataTransfer data)
    {
        _characteristics = data.Characteristics;
        CurrentAttributes = data.StartAttributes;
        MaxAttributes = data.MaxAttributes;
    }




}
