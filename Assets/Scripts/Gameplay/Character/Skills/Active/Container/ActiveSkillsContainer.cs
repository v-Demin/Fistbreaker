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
    private ComboContainer _combo;

    private Dictionary<ActiveSkill, Combination> _skills = new ();

    public ActiveSkillsContainer(Character owner, ComboContainer combo)
    {
        _owner = owner;
        _combo = combo;
    }
    
    public void AddSkill(Combination combination, ActiveSkill skill)
    {
        _combo.Register(combination);
        _skills.Add(skill, combination);

        combination.OnCombinationExecuted += () => skill.Action(_owner, _battleController.GetEnemyFor(_owner));
    }

    public void RemoveSkill(ActiveSkill skill)
    {
        _combo.Unregister(_skills[skill]);
        _skills.Remove(skill);

        _skills[skill].OnCombinationExecuted -= () => skill.Action(_owner, _battleController.GetEnemyFor(_owner));
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
