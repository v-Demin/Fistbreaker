using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/ActiveSkill")]
public class PassiveSkill : AbstractSkill
{
    [SerializeField] private List<AbstractPassiveSkillAction> _actions;

    
    public virtual void OnActivation(Character owner)
    {
        _actions.ForEach(action => action.ExecuteActivation(owner));
    }

    public virtual void OnDeactivation(Character owner)
    {
        _actions.ForEach(action => action.ExecuteDeactivation(owner));
    }
}
