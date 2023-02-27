using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestActiveSkillActionT : AbstractActiveSkillAction
{
    [SerializeField] private Color _color;
    [SerializeField] private string _testMessage;

    public override void Execute(Character owner, Character enemy)
    {
        $"{_testMessage}, тестовое действие {GetType()} сработало".Log(_color);
    }
}
