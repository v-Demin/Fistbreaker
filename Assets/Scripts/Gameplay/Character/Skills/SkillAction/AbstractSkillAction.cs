using UnityEngine;

public abstract class AbstractSkillAction : ScriptableObject
{
    public abstract void Action();

    public override string ToString()
    {
        return GetType().ToString();
    }
}
