using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Passive/Actions/AddCharacteristics")]
public class AddCharacteristics : AbstractPassiveSkillAction
{
    [SerializeField] private List<CharacteristicsInfo> _info;

    public override void ExecuteActivation(Character owner)
    {
        _info.ForEach(info => owner.Characteristics.AddCharacteristic(info.Type, info.Value));
    }

    public override void ExecuteDeactivation(Character owner)
    {
        _info.ForEach(info => owner.Characteristics.AddCharacteristic(info.Type, -info.Value));
    }
    
    [System.Serializable]
    private class CharacteristicsInfo
    {
        public CharacteristicType Type;
        public float Value;
    }
}
