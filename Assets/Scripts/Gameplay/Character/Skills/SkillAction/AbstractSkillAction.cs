using UnityEngine;

public abstract class AbstractSkillAction : ScriptableObject
{
    public abstract void Action(Character owner, Character enemy);

    public override string ToString()
    {
        return GetType().ToString();
    }
}
