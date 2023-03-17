using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour, IEnablable
{
    [Inject] private readonly DiContainer _container;

    public AttributesContainer Attributes;
    public CharacteristicContainer Characteristics;
    
    private ActiveSkillsContainer _activeSkills;
    private PassiveSkillContainer _passiveSkills;
    private ExperienceContainer _exp;
    private ControlContainer _control;
    private PowerContainer _power;

    public void Init()
    {
        _control = _container.Instantiate<ControlContainer>();
        
        Characteristics = new CharacteristicContainer(new List<BaseCharacteristic>()
        {
            new Strength(1),
            new Agility(2),
            new Endurance(6),
            new Intelligence(4),
            new Willpower(5),
            new Perception(6)
        });
        
        Attributes = new AttributesContainer(new AttributesDataTransfer(Characteristics, new MaxAttributes(Characteristics)));
        
        _activeSkills = _container.Instantiate<ActiveSkillsContainer>(new List<object> {this, _control});
        _passiveSkills = new PassiveSkillContainer(this);
        _power = new PowerContainer(Attributes);

        DebugTest();
    }

    public void Enable()
    {
        _control.Enable();
    }

    public void Disable()
    {
        _control.Disable();
    }
    
    [SerializeField] private ActiveSkill _skill;
    [SerializeField] private PassiveSkill _passiveSkill;
    private void DebugTest()
    {
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Up}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Left}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Right}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Down}), _skill);
        _passiveSkills.AddSkill(_passiveSkill);
    }
}
