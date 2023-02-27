using UnityEngine;

[CreateAssetMenu]
public class DealDamageSkillAction : AbstractSkillAction
{
    [SerializeField] private CharacteristicType _damageCharacteric;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _damageMuliplier;

    [SerializeField] private CharacteristicType _critChanceCharacteristic;
    [SerializeField] private float _baseCritChance;
    [SerializeField] private float _critChanceMuliplier;

    [SerializeField] private CharacteristicType _critDamageCharacteristic;
    [SerializeField] private float _baseCritDamage;
    [SerializeField] private float _critDamageMuliplier;

    public override void Action(Character owner, Character enemy)
    {
        float damage = -_baseDamage + _damageMuliplier * owner.Attributes.DamageModifyer(_damageCharacteric);
        if (IsCritApplied(_baseCritChance + _critChanceMuliplier * owner.Attributes.BaseCritChance(_critChanceCharacteristic)))
            damage *= _baseCritDamage * _critDamageMuliplier * owner.Attributes.CritDamageModifyer(_critDamageCharacteristic);
        
        $"Исходящий урон {damage}".Log(Color.green);
        
        enemy.Attributes.ChangeHealth(damage);
    }
}
