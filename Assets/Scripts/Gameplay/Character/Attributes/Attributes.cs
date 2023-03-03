using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Attributes
{
    protected float _baseHealth;
    protected float _baseStamina;
    protected float _baseMana;
    public virtual float Health => _baseHealth;
    public virtual float Stamina => _baseStamina;
    public virtual float Mana => _baseMana;
    
    public Attributes(float baseHealth, float baseStamina, float baseMana)
    {
        _baseHealth = baseHealth;
        _baseStamina = baseStamina;
        _baseMana = baseMana;
    }
    
    public Attributes(Attributes attributes) :
        this(attributes._baseHealth, attributes._baseStamina, attributes._baseMana)
    {
    }

    public static Attributes Clamp(Attributes attributes, Attributes maxValues)
    {
        return new Attributes(
            Mathf.Clamp(attributes.Health, 0, maxValues.Health),
            Mathf.Clamp(attributes.Stamina, 0, maxValues.Stamina),
            Math.Clamp(attributes.Mana, 0, maxValues.Mana));
    }

    public void Refresh(MaxAttributes maxAttributes)
    {
        
    }

    public void Add(Attributes attributes)
    {
        _baseHealth += attributes._baseHealth;
        _baseStamina += attributes._baseStamina;
        _baseMana += attributes._baseMana;
    }
    
    public void SetFrom(Attributes attributes)
    {
        _baseHealth = attributes._baseHealth;
        _baseStamina = attributes._baseStamina;
        _baseMana = attributes._baseMana;
    }
}
