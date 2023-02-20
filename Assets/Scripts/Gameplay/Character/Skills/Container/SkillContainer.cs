using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class SkillContainer
{
   
    [Inject] private readonly InputTaker _inputTaker;

    private Dictionary<Combination, BaseSkill> _skills = new Dictionary<Combination, BaseSkill>();

    public SkillContainer(DiContainer container)
    {
        _inputTaker = container.Resolve<InputTaker>();
        _inputTaker.OnKeyUpdate += OnKeyUpdated;
    }
    
    public void AddSkill(Combination combination, BaseSkill skill)
    {
        _skills.Add(combination, skill);
    }

    private void OnKeyUpdated(List<InputKey> keyList)
    {
        if(keyList.Count == 0) return;

        var combinationToCheck = new Combination(keyList);

        if (keyList.Contains(InputKey.Down) && keyList.Count >= 1)
        {
            "Задавнили".Log(Color.red);
            _inputTaker.ResetKeys();
            return;
        }

        if (!IsAnySkillsAccessable(combinationToCheck))
        {
            "Ни одного скилла недоступно".Log(Color.red);
            _inputTaker.ResetKeys();
            return;
        }
        
        if (FindInvokableSkill(combinationToCheck) != null)
        {
            "Успешный инвок".Log(Color.red);
            FindInvokableSkill(combinationToCheck).Action();
            _inputTaker.ResetKeys();
            return;
        }
    }

    public bool IsAnySkillsAccessable(Combination combination) =>
        _skills.Any(pair => pair.Key.IsAccessable(combination));

    public BaseSkill FindInvokableSkill(Combination combination) =>
        _skills.FirstOrDefault(pair => pair.Key.IsKeysEquals(combination)).Value;
    
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
