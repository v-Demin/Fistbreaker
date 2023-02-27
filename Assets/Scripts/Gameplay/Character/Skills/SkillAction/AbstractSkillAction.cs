using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class AbstractSkillAction : ScriptableObject
{
    
    public abstract void Action(Character owner, Character enemy);

    protected virtual bool IsCritApplied(float critChance) => critChance >= 1 || Random.Range(0f, 1f) <= critChance;

    public override string ToString()
    {
        return GetType().ToString();
    }
}
