using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAttributes : Attributes
{
    public override float Health => _baseHealth +
                                    _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.HEALTH_PER_ENDURANCE;

    public override float Stamina => _baseStamina +
                                     _characteristics.GetCharacteristic(CharacteristicType.Perception).Value * GameConstants.STAMINA_PER_PERCEPTION +
                                     _characteristics.GetCharacteristic(CharacteristicType.Agility).Value * GameConstants.STAMINA_PER_AGILITY;

    public override float Mana => _baseMana +
                                  _characteristics.GetCharacteristic(CharacteristicType.Intelligence).Value * GameConstants.MANA_PER_INTELLIGENCE;

    private CharacteristicContainer _characteristics;

    public MaxAttributes(CharacteristicContainer characteristics) :
        this(characteristics, GameConstants.BASE_HEALTH, GameConstants.BASE_STAMINA, GameConstants.BASE_MANA)
    {
    }
    
    public MaxAttributes(CharacteristicContainer characteristics, float baseHealth, float baseStamina, float baseMana) : base(baseHealth, baseStamina, baseMana)
    {
        _characteristics = characteristics;
    }
}
