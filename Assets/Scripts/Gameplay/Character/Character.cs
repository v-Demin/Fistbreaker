using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;

    public AttributesContainer Attributes;
    public CharacteristicContainer Characteristics;
    
    private SkillContainer _skills;
    private ExperienceContainer _exp;
    
    [SerializeField] private BaseSkill _skill;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
        Attributes = new AttributesContainer(new AttributesDataTransfer(Characteristics, _exp, new Attributes(200, 20),
            new Attributes(1600, 60)));
        
        _skills = new SkillContainer(_container, this);
        
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right}), _skill);
    }
}
