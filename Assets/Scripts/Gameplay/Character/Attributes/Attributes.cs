using System;
using UnityEngine;

public class Attributes
{
    public Action<Attributes> OnCurrentAttributesChanged;
    public Action OnHealthOver;

    private float _health;
    private float _mana;

    public float Health => _health;
    public float Mana => _mana;
    
    private MaxAttributes _maxAttributes;
    
    public Attributes(MaxAttributes maxAttributes) : this(maxAttributes.Health, maxAttributes.Mana)
    {
        _maxAttributes = maxAttributes;
    }
    
    private Attributes(float health, float mana)
    {
        _health = health;
        _mana = mana;
    }

    public void ChangeValues(float health, float stamina, float mana)
    {
        ChangeValue(ref _health, health, _maxAttributes.Health);
        ChangeValue(ref _mana, mana, _maxAttributes.Mana);
        
        OnCurrentAttributesChanged?.Invoke(this);
        if (Health <= 0)
        {
            OnHealthOver?.Invoke();
        }
    }

    private void ChangeValue(ref float value, float addValue, float maxValue) => value = Mathf.Clamp(value + addValue, 0f, maxValue);
    
    public void ToMax()
    {
        _health = _maxAttributes.Health;
        _mana = _maxAttributes.Mana;
    }
    
    private void Refresh()
    {
        // ChangeHealth(_maxAttributes.Health * (GameConstants.BASE_HEALTH_RESTORE_PERCENTAGE_ON_NEXT_ROUND_STARTED +
        //              _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.ADDITONAL_HEALTH_RESTORE_PERCENTAGE_ON_NEXT_ROUND_FROM_ENDURANCE +
        //              _characteristics.GetCharacteristic(CharacteristicType.Willpower).Value * GameConstants.ADDITONAL_HEALTH_RESTORE_PERCENTAGE_ON_NEXT_ROUND_FROM_WILLPOWER));
        //
        // ChangeStamina(_maxAttributes.Stamina);
        //
        // ChangeMana(_maxAttributes.Mana * (GameConstants.BASE_MANA_RESTORE_PERCENTAGE_ON_NEXT_ROUND_STARTED +
        //            _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.ADDITONAL_MANA_RESTORE_PERCENTAGE_ON_NEXT_ROUND_FROM_INTELLEGENCE +
        //            _characteristics.GetCharacteristic(CharacteristicType.Willpower).Value * GameConstants.ADDITONAL_MANA_RESTORE_PERCENTAGE_ON_NEXT_ROUND_FROM_WILLPOWER));
    }
}
