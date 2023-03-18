using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Active/Actions/DealDamageOverTime")]
public class DealDamageOverTimeSkillAction : DealDamageActiveSkillAction
{
    [Header("DOT")]
    [SerializeField] private float _damageRate;
    [SerializeField] private int _damageCount;
    
    public override void Execute(Character owner, Character enemy)
    {
        var damageSequence = DOTween.Sequence();

        for (int i = 0; i < _damageCount; i++)
        {
            damageSequence.InsertCallback(_damageRate * i, () => DealDamage(owner, enemy));
        }
    }
}
