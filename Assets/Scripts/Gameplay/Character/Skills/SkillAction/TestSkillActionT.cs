using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestSkillActionT : AbstractSkillAction
{
    [SerializeField] private Color _color;
    [SerializeField] private string _testMessage;
    public override void Action()
    {
        $"{_testMessage}, тестовое действие {GetType()} сработало".Log(_color);
    }
}
