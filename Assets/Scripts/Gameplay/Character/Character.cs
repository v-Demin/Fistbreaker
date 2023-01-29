using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;

    private CharacteristicContainer _characteristics;
    
    private SkillContainer _skillContainer;
    [SerializeField] private BaseSkill _skill;

    private void Start()
    {
        _skillContainer = new SkillContainer(_container);
        _skillContainer.AddSkill(_skill);
        
        _characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
    }
}
