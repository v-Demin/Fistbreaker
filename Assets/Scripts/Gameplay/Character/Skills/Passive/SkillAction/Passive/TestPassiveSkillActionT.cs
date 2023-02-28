using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Passive/Actions/_test")]
public class TestPassiveSkillActionT : AbstractPassiveSkillAction
{
    [SerializeField] private Color _color;
    [SerializeField] private string _testActivationMessage;
    [SerializeField] private string _testDeactivationMessage;

    public override void ExecuteActivation(Character owner)
    {
        _testActivationMessage.Log(_color);
    }

    public override void ExecuteDeactivation(Character owner)
    {
        _testDeactivationMessage.Log(_color);
    }
}
