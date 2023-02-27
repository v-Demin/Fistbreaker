using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using Zenject;

public class SkillContainer: IDisposable
{
    [Inject] private readonly InputTaker _inputTaker;
    [Inject] private readonly GameCycleController _cycleController;

    private Character _owner;

    private Dictionary<Combination, ActiveSkill> _skills = new ();

    public SkillContainer(DiContainer container, Character owner)
    {
        _inputTaker = container.Resolve<InputTaker>();
        _cycleController = container.Resolve<GameCycleController>();
        _owner = owner;
        
        _inputTaker.OnKeyUpdate += OnKeyUpdated;
    }
    
    public void Dispose()
    {
        _inputTaker.OnKeyUpdate -= OnKeyUpdated;
    }
    
    public void AddSkill(Combination combination, ActiveSkill skill)
    {
        _skills.Add(combination, skill);
    }

    private void OnKeyUpdated(List<InputKey> keyList)
    {
        if(keyList.Count == 0) return;

        var combinationToCheck = new Combination(keyList);

        if (keyList.Contains(InputKey.Down) && keyList.Count >= 1)
        {
            _inputTaker.ResetKeys();
            return;
        }

        if (!IsAnySkillsAccessable(combinationToCheck))
        {
            _inputTaker.ResetKeys();
            return;
        }

        var skill = FindInvokableSkill(combinationToCheck);
        
        if (skill != null)
        {
            skill.Action(_owner, _cycleController.GetEnemyFor(_owner));
            _inputTaker.ResetKeys();
            return;
        }
    }

    public bool IsAnySkillsAccessable(Combination combination) =>
        _skills.Any(pair => pair.Key.IsAccessable(combination));

    public ActiveSkill FindInvokableSkill(Combination combination) =>
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
