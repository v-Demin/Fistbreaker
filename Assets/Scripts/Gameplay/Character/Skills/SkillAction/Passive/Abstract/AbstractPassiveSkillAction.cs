using UnityEngine;

public abstract class AbstractPassiveSkillAction : ScriptableObject
{
    public abstract void ExecuteActivation(Character owner);
    public abstract void ExecuteDeactivation(Character owner);

    public override string ToString()
    {
        return GetType().ToString();
    }
}