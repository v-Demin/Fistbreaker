using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ModestTree;
using Zenject;

public class ActiveSkillsContainer
{
    [Inject] private readonly BattleController _battleController;

    private Character _owner;
    private ControlContainer _control;

    private Dictionary<ControlCombination, ActiveSkill> _skills = new ();

    public ActiveSkillsContainer(Character owner, ControlContainer control)
    {
        _owner = owner;
        _control = control;
    }
    
    public void AddSkill(ControlCombination controlCombination, ActiveSkill skill)
    {
        _control.Register(controlCombination);
        _skills.Add(controlCombination, skill);

        controlCombination.OnCombinationExecuted += () => skill.Action(_owner, _battleController.GetCombo(_owner), _battleController.GetEnemyFor(_owner));
    }

    public void RemoveSkill(ActiveSkill skill)
    {
        // _combo.Unregister(_skills[skill]);
        // _skills.Remove(skill);
        //
        // _skills[skill].OnCombinationExecuted -= () => skill.Action(_owner, _battleController.GetEnemyFor(_owner));
    }
    
    public override string ToString()
    {
        if (_skills.IsEmpty())
        {
            return "";
        }
        return _skills
            .Select(c => c.ToString())
            .Aggregate((current, next) => current + '\n' + next);
    }
}
