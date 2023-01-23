using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacteristicContainer
{
    private List<BaseCharacteristic> _characteristics;
    
    public T GetCharacteristic<T>() where T : BaseCharacteristic =>
        _characteristics.FirstOrDefault(c => c is T) as T;

    public void AddCharacteristic<T>(float addValue) where T : BaseCharacteristic
    {
        GetCharacteristic<T>().AddValue(addValue);
    }

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
    
    public CharacteristicContainer(List<float> values)
    {
        _characteristics = new List<BaseCharacteristic>()
        {
            new Strength(values[0]),
            new Agility(values[1]),
            new Endurance(values[2]),
            new Intelligence(values[3]),
            new Perception(values[4]),
            new Willpower(values[5])
        };
        _characteristics.Add(new Balance(ref _characteristics));
    }

    public override string ToString()
    {
        GetCharacteristic<Balance>().Log(Color.cyan);

        return _characteristics
            .Select(c => c.ToString())
            .Aggregate((current, next) => current + '\n' + next);
    }

    #endregion
}
