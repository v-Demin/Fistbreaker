using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Active/Actions/_test")]
public class TestActiveSkillActionT : AbstractActiveSkillAction
{
    [SerializeField] private Color _color;
    [SerializeField] private string _testMessage;

    public override void Execute(Character owner, Character enemy)
    {
        $"{_testMessage}".Log(_color);
    }
}
