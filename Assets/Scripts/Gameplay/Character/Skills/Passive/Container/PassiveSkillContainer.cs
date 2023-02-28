using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Zenject;

public class PassiveSkillContainer
{
    private Character _owner;

    private List<PassiveSkill> _skills = new ();

    [Inject]
    public PassiveSkillContainer(Character owner)
    {
        _owner = owner;
    }
    
    public void AddSkill(PassiveSkill skill)
    {
        skill.Activate(_owner);
        _skills.Add(skill);
    }

    public void RemoveSkill(PassiveSkill skill)
    {
        skill.Deactivate(_owner);
        _skills.Remove(skill);
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
