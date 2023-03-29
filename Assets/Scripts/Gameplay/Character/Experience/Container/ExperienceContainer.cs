using System;
using UnityEngine;

public class ExperienceContainer
{
    private Level _level;
    private Exp _exp;
    
    private Func<int, int> FibonacciSequence = n => (int)((Mathf.Pow((Mathf.Sqrt(5) + 1) / 2, n)) / Mathf.Sqrt(5) + 0.5f);
    public int NextLevelExp => FibonacciSequence(_level.Value) * 100;

    public ExperienceContainer(Level level, Exp exp)
    {
        _level = level;
        _exp = exp;
    }
}