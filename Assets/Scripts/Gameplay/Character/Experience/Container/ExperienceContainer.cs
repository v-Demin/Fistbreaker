using System;
using UnityEngine;

public class ExperienceContainer
{
    public Action<Level> LevelUp;
    
    private Level _level;
    private Exp _exp;
    
    private Func<int, int> FibonacciSequence = n => (int)((Mathf.Pow((Mathf.Sqrt(5) + 1) / 2, n)) / Mathf.Sqrt(5) + 0.5f);
    public int CurrentLevel => _level.Value;
    public int CurrentExp => _exp.Value;
    public int NextLevelExp => FibonacciSequence(_level.Value) * 100;

    public ExperienceContainer(Level level, Exp exp)
    {
        _level = level;
        _exp = new Exp();

        AddExp(exp.Value);
    }

    public void AddExp(int value)
    {
        _exp.Value += value;
        
        while (_exp.Value >= NextLevelExp)
        {
            _exp.Value -= NextLevelExp;
            AddLevel();
        }
    }

    public void AddLevel()
    {
        _level.Value++;
        LevelUp?.Invoke(_level);
    }
}