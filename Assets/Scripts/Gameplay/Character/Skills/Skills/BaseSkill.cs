using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class BaseSkill : ScriptableObject
{
    [SerializeField] private List<InputKey> _keys;
    [SerializeField] private List<AbstractSkillAction> _skillActions;

    public bool IsAccessable(List<InputKey> list) => list.SequenceEqual(_keys);
    public bool IsKeysEquals(List<InputKey> list) => IsAccessable(list) && (list.Count == _keys.Count);

    public bool TryToAction(List<InputKey> list)
    {
        if(IsKeysEquals(list)) Action();
        return IsKeysEquals(list);
    }

    protected virtual void Action()
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
