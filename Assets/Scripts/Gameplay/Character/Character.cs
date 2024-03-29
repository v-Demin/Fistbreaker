using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour, IEnablable
{
    [Inject] private readonly DiContainer _container;
    
    [field: SerializeField] public Animator Animator { get; private set; }

    public Bio Bio;
    public AttributesContainer Attributes;
    public CharacteristicContainer Characteristics;
    public ExperienceContainer Exp;
    
    private ActiveSkillsContainer _activeSkills;
    private PassiveSkillContainer _passiveSkills;
    private ControlContainer _control;
    private PowerContainer _power;

    public void Init()
    {
        Bio = _container.Instantiate<Bio>();
        
        _control = _container.Instantiate<ControlContainer>();

        Exp = new ExperienceContainer(new Level(), new Exp(Random.Range(0, 10000)));
        
        Characteristics = new CharacteristicContainer(new List<BaseCharacteristic>()
        {
            new Strength(1),
            new Agility(2),
            new Endurance(6000),
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
        gameObject.SetActive(true);
        _control.Enable();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
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
