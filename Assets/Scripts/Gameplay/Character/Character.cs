using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private BasePower _power;

    private CharacteristicContainer _characteristics;
    
    private List<AbstractSkill> _skillSet;

    private void Start()
    {
        _characteristics = new CharacteristicContainer(new List<float>() {1, 2, 3, 4, 5, 6});
        _characteristics.Log(Color.yellow);
    }
}
