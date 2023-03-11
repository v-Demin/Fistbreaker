using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class RhythmGameplayController : MonoBehaviour
{
    public Action TimeKeyInvoke;
    
    [field: SerializeField] public float Speed { get; private set; }
    [SerializeField] private RythmSequence _sequence;

    public void OnObjectHit()
    {
        $"Попел".Log(Color.red);
    }
    
    public void OnObjectMiss()
    {
        $"Пропустил".Log(Color.red);
    }

    public void OnKeyMiss()
    {
        $"Акелла промахнулся".Log(Color.red);
    }

    private void Start()
    {
        var sequence = DOTween.Sequence();
        _sequence.Timings.ForEach(value =>
        {
            sequence.InsertCallback(value, () => TimeKeyInvoke?.Invoke());
        });
    }
}
