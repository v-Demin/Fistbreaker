using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class SPView : MonoBehaviour
{
    [Inject] private readonly SPTimer _sp;
    
    [SerializeField] private BaseViewBar _bar;
    
    private void Start()
    {
        _sp.OnTimeUpdated += ((currentTime, lerp) =>
        {
            _bar.UpdateText(currentTime);
            _bar.UpdateBar(lerp);
        });
    }
}
