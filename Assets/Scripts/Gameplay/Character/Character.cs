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
    private ComboContainer _combo;

    [SerializeField] private bool ISTAKINGINPUT_TODELETE;
    

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _combo = _container.Instantiate<ComboContainer>().Init(ISTAKINGINPUT_TODELETE);
        
        Characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
        Attributes = new AttributesContainer(new AttributesDataTransfer(Characteristics, _exp, new Attributes(200, 20),
            new Attributes(1600, 60)));
        
        _activeSkills = _container.Instantiate<ActiveSkillsContainer>(new List<object> {this, _combo});
        _passiveSkills = new PassiveSkillContainer(this);

        DebugTest();
    }
    
    [SerializeField] private ActiveSkill _skill;
    [SerializeField] private PassiveSkill _passiveSkill;
    private void DebugTest()
    {
        _activeSkills.AddSkill(new Combination(new List<InputKey>(){InputKey.Up}), _skill);
        _passiveSkills.AddSkill(_passiveSkill);
    }
}
