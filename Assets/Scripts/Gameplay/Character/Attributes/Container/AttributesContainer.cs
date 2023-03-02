using System;
using UnityEngine;

public class AttributesContainer
{
    private readonly CharacteristicContainer _characteristics;
    private readonly ExperienceContainer _experiences;

    public Action<Attributes> OnCurrentAttributesChanged;
    public Action<Attributes> OnMaxAttributesChanged;
    public Action OnHealthOver;

    //[Todo:] формулы
    public float DamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float EffectModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float CritDamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float BaseCritChance(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float DefendModifyer => _characteristics.GetCharacteristic(CharacteristicType.Balance).Value;
    public float PowerModifyer => _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value;
    
    private Attributes _currentAttributes;
    private Attributes _maxAttributes;

    public AttributesContainer(AttributesDataTransfer data)
    {
        _characteristics = data.Characteristics;
        _experiences = data.Experiences;
        _currentAttributes = data.StartAttributes;
        _maxAttributes = data.MaxAttributes;
    }

    public void ChangeHealth(float value) => UpdateCurrentAttributes(new Attributes(value, 0));
    public void ChangeSp(float value) => UpdateCurrentAttributes(new Attributes(0, value));

    private void UpdateCurrentAttributes(Attributes changeValue)
    {
        _currentAttributes += changeValue;
        _currentAttributes = Attributes.Clamp(_currentAttributes, _maxAttributes);
        OnCurrentAttributesChanged?.Invoke(_currentAttributes);
        if (_currentAttributes.Health <= 0)
        {
            $"Умёр".Log(Color.black);
            OnHealthOver?.Invoke();
        }
    }
}
