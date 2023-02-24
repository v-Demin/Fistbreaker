using System;

public class AttributesContainer
{
    private readonly CharacteristicContainer _characteristics;
    private readonly ExperienceContainer _experiences;

    public Action<Attributes> OnCurrentAttributesChanged;
    public Action<Attributes> OnMaxAttributesChanged;
    public Action OnHealthOver;

    //[Todo:] формулы (участие характеристик и опытов)
    public float DamageModifyer<T>() where T : BaseBodyCharacteristic => _characteristics.GetCharacteristic<T>().Value;
    public float EffectModifyer<T>() where T : BaseCharacteristic => _characteristics.GetCharacteristic<T>().Value;
    public float CritDamageModifyer<T>() where T : BaseCharacteristic => _characteristics.GetCharacteristic<T>().Value;
    public float CritChanceModifyer<T>() where T : BaseCharacteristic => _characteristics.GetCharacteristic<T>().Value;
    public float DefendModifyer<T>() where T : Endurance => _characteristics.GetCharacteristic<T>().Value;

    private Attributes _currentAttributes;
    private Attributes _maxAttributes;

    public AttributesContainer(AttributesDataTransfer data)
    {
        _characteristics = data.Characteristics;
        _experiences = data.Experiences;
        _currentAttributes = data.StartAttributes;
        _maxAttributes = data.MaxAttributes;
    }

    public void ChangeHealth(float value)
    {
        var health = _currentAttributes.Health;
        UpdateCurrentAttributes(new Attributes(value, 0));
        $"Получаю изменение хепе {value}, хепе было: {health}, хепе стало: {_currentAttributes.Health}".LogBool(_currentAttributes.Health > health);
    }
    
    public void ChangeSp(float value)
    {
        UpdateCurrentAttributes(new Attributes(0, value));
    }

    private void UpdateCurrentAttributes(Attributes changeValue)
    {
        _currentAttributes += changeValue;
        _currentAttributes = Attributes.Clamp(_currentAttributes, _maxAttributes);
        OnCurrentAttributesChanged?.Invoke(_currentAttributes);
        if(_currentAttributes.Health <= 0) {OnHealthOver?.Invoke();}
    }
}
