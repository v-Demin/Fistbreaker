using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using Zenject;

public class SkillContainer
{
    [Inject] private readonly InputTaker _inputTaker;

    private List<BaseSkill> _skills = new List<BaseSkill>();

    public SkillContainer(DiContainer container)
    {
        _inputTaker = container.Resolve<InputTaker>();
        _inputTaker.OnKeyUpdate += OnKeyUpdated;
    }
    
    public void AddSkill(BaseSkill skill)
    {
        _skills.Add(skill);
    }

    private void OnKeyUpdated(List<InputKey> keyList)
    {
        if (keyList.Contains(InputKey.Down) && keyList.Count >= 1)
        {
            "Задавнили".Log(Color.red);
            _inputTaker.ResetKeys();
            return;
        }
        
        if (!CheckIsSkillsAccessable(keyList))
        {
            "Не одного скилла недоступно".Log(Color.red);
            _inputTaker.ResetKeys();
            return;
        }
        
        if (TryToInvokeSkills(keyList))
        {
            "Успешный инвок".Log(Color.red);
            _inputTaker.ResetKeys();
            return;
        }
    }

    public bool CheckIsSkillsAccessable(List<InputKey> list)
    {
        return _skills.Any(skill => skill.IsAccessable(list));
    }
    
    public bool TryToInvokeSkills(List<InputKey> list)
    {
        return _skills.Find(skill => skill.TryToAction(list));
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
