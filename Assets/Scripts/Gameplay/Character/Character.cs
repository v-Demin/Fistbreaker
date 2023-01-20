using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    private List<AbstractCharacteristic> _characteristics;
    public T GetCharacteristic<T>() where T : AbstractCharacteristic =>
        _characteristics.FirstOrDefault(c => c is T) as T;

    private Balance _balance;
    
    private List<AbstractSkill> _skillSet;

    private void Awake()
    {
        _characteristics = new List<AbstractCharacteristic>()
        {
            new Strength(), new Agility(), new Endurance(),
            new Intelligence(), new Perception(), new Willpower()
        };
        _balance = new Balance(ref _characteristics);
    }

    private void Start()
    {
        _characteristics.ForEach(c => c.Log(Color.yellow));
        _balance.Log(Color.red);
    }
}
