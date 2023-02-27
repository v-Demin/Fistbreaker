using System;
using System.Collections.Generic;

public static class CharacteristicHelp
{
    private static Dictionary<CharacteristicType, Type> _typeDictionary = new()
    {
        {CharacteristicType.Strength, typeof(Strength)},
        {CharacteristicType.Agility, typeof(Agility)},
        {CharacteristicType.Endurance, typeof(Endurance)},
        {CharacteristicType.Perception, typeof(Perception)},
        {CharacteristicType.Intelligence, typeof(Intelligence)},
        {CharacteristicType.Willpower, typeof(Willpower)},
        {CharacteristicType.Balance, typeof(Balance)},
    };

    public static Type FromEnum(CharacteristicType type)
    {
        return _typeDictionary[type];
    }
}
