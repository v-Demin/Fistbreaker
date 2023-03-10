using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAttributes
{
    public float Health => GameConstants.BASE_HEALTH +
                           _characteristics.GetCharacteristic(CharacteristicType.Endurance).Value * GameConstants.HEALTH_PER_ENDURANCE;

    public float Stamina => GameConstants.BASE_ROUND_DURATION + 
                            _characteristics.GetCharacteristic(CharacteristicType.Perception).Value * GameConstants.STAMINA_PER_PERCEPTION +
                            _characteristics.GetCharacteristic(CharacteristicType.Agility).Value * GameConstants.STAMINA_PER_AGILITY;

    public float Mana => GameConstants.BASE_MANA +
                         _characteristics.GetCharacteristic(CharacteristicType.Intelligence).Value * GameConstants.MANA_PER_INTELLIGENCE;

    private CharacteristicContainer _characteristics;

    public MaxAttributes(CharacteristicContainer characteristics)
    {
        _characteristics = characteristics;
    }
}
