using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class BaseSkill : ScriptableObject
{
    [SerializeField] private List<AbstractSkillAction> _skillActions;

    public virtual void Action()
    {
        $"Пытаемся дёрнуть {name}".Log(Color.green);
        _skillActions.ForEach(action => action.Action());
    }

    public override string ToString()
    {
        return _skillActions
            .Select(c => c.ToString())
            .Aggregate((current, next) => current + '\n' + next);
    }
}
