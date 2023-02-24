using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;

    public AttributesContainer Attributes;

    private CharacteristicContainer _characteristics;
    private SkillContainer _skills;
    private ExperienceContainer _exp;
    
    [SerializeField] private BaseSkill _skill;
    [SerializeField] private BaseSkill _skill2;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
        Attributes = new AttributesContainer(new AttributesDataTransfer(_characteristics, _exp, new Attributes(20, 20),
            new Attributes(40, 60)));
        
        _skills = new SkillContainer(_container, this);
        
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Up}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Right}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Left}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Up}), _skill2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Attributes.ChangeHealth(2.1f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Attributes.ChangeHealth(-0.1f);
        }
    }
}
