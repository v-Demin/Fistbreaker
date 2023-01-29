using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestSkillActionT : AbstractSkillAction
{
    public override void Action()
    {
        $"Тестовое действие {GetType()} сработало".Log(Color.black);
    }
}
