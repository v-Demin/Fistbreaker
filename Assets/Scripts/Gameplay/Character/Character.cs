using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    

    public AttributesContainer Attributes;
    public CharacteristicContainer Characteristics;
    
    private ActiveSkillsContainer _activeSkills;
    private PassiveSkillContainer _passiveSkills;
    private ExperienceContainer _exp;
    private ControlContainer _control;
    private PowerContainer _power;

    [SerializeField] private bool ISTAKINGINPUT_TODELETE;
    

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _control = _container.Instantiate<ControlContainer>().Init(ISTAKINGINPUT_TODELETE);
        
        Characteristics = new CharacteristicContainer(new List<BaseCharacteristic>()
        {
            new Strength(1),
            new Agility(2),
            new Endurance(300),
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
    
    [SerializeField] private ActiveSkill _skill;
    [SerializeField] private PassiveSkill _passiveSkill;
    private void DebugTest()
    {
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Up}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Left}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Right}), _skill);
        _activeSkills.AddSkill(new ControlCombination(new List<InputKey>(){InputKey.Down}), _skill);
        _passiveSkills.AddSkill(_passiveSkill);
        $"{name}: {Attributes.CurrentAttributes.Stamina}, {Attributes.MaxAttributes.Stamina}".Log(Color.green);
    }
}
