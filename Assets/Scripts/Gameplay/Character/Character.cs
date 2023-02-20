using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;

    private CharacteristicContainer _characteristics;
    private SkillContainer _skills;
    //private ExperiencesContainer _exp;
    //private  _exp;
    
    [SerializeField] private BaseSkill _skill;
    [SerializeField] private BaseSkill _skill2;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _skills = new SkillContainer(_container);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Up}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Right}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Right, InputKey.Left}), _skill);
        _skills.AddSkill(new Combination(new List<InputKey>(){InputKey.Up}), _skill2);
        _characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
    }
}
