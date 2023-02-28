using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Passive/PassiveSkill")]
public class PassiveSkill : AbstractSkill
{
    [SerializeField] private List<AbstractPassiveSkillAction> _actions;

    public virtual void Activate(Character owner)
    {
        _actions.ForEach(action => action.ExecuteActivation(owner));
    }

    public virtual void Deactivate(Character owner)
    {
        _actions.ForEach(action => action.ExecuteDeactivation(owner));
    }
}
