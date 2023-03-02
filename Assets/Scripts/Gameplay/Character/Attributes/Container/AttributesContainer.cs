using System;
using UnityEngine;

public class AttributesContainer
{
    private readonly CharacteristicContainer _characteristics;

    public Action<Attributes> OnCurrentAttributesChanged;
    public Action<Attributes> OnMaxAttributesChanged;
    public Action OnHealthOver;

    private float CharacteristicValue(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;

    //[Todo:] формулы
    public float DamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float EffectModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float CritDamageModifyer(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float BaseCritChance(CharacteristicType type) => _characteristics.GetCharacteristic(type).Value;
    public float DefendModifyer => _characteristics.GetCharacteristic(CharacteristicType.Balance).Value;
    public float PowerModifyer => _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value;
    
    private Attributes _currentAttributes;
    private MaxAttributes _maxAttributes;

    public AttributesContainer(AttributesDataTransfer data)
    {
        _characteristics = data.Characteristics;
        _currentAttributes = data.StartAttributes;
        _maxAttributes = data.MaxAttributes;
    }

    public void ChangeHealth(float value) => UpdateCurrentAttributes(new Attributes(value, 0, 0));
    public void ChangeSp(float value) => UpdateCurrentAttributes(new Attributes(0, value, 0));
    public void ChangeMana(float value) => UpdateCurrentAttributes(new Attributes(0, 0, value));

    private void OnRoundStarted()
    {
        _currentAttributes.SetFrom(_maxAttributes);
    }
    
    private void OnRoundUpdated()
    {
        ChangeHealth(_maxAttributes.Health * (GameConstants.BASE_HEALTH_RESTORE_PROCENTAGE_ON_NEXT_ROUND_STARTED +
                     _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.ADDITONAL_HEALTH_RESTORE_PRECENTAGE_ON_NEXT_ROUND_FROM_ENDURANCE +
                     _characteristics.GetCharacteristic(CharacteristicType.Willpower).Value * GameConstants.ADDITONAL_HEALTH_RESTORE_PRECENTAGE_ON_NEXT_ROUND_FROM_WILLPOWER));
        
        ChangeSp(_maxAttributes.Stamina);
        
        ChangeMana(_maxAttributes.Mana * (GameConstants.BASE_MANA_RESTORE_PROCENTAGE_ON_NEXT_ROUND_STARTED +
                   _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.ADDITONAL_MANA_RESTORE_PRECENTAGE_ON_NEXT_ROUND_FROM_INTELLEGENCE +
                   _characteristics.GetCharacteristic(CharacteristicType.Willpower).Value * GameConstants.ADDITONAL_MANA_RESTORE_PRECENTAGE_ON_NEXT_ROUND_FROM_WILLPOWER));
    }

    private void UpdateCurrentAttributes(Attributes changeValue)
    {
        _currentAttributes.Add(changeValue);
        _currentAttributes = Attributes.Clamp(_currentAttributes, _maxAttributes);
        OnCurrentAttributesChanged?.Invoke(_currentAttributes);
        if (_currentAttributes.Health <= 0)
        {
            $"Умёр".Log(Color.black);
            OnHealthOver?.Invoke();
        }
    }
}
