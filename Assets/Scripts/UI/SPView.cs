using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SPView : MonoBehaviour
{
    [SerializeField] private SPTimer _sp;
    //[Todo]: заменить на отдельные классы
    [SerializeField] private TextMeshPro _textMesh;
    [SerializeField] private Transform _bar;
    
    private void Start()
    {
        _sp.OnTimeUpdated += ((currentTime, lerp) =>
        {
            UpdateText(currentTime);
            UpdateBar(lerp);
        });
    }

    private void UpdateText(float time)
    {
        _textMesh.text = time.ToString("0.00");
    }

    private void UpdateBar(float lerp)
    {
        _bar.localScale = new Vector3(1 - lerp, 1f, 1f);
    }
}
