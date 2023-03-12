using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class RhythmGameplayController : MonoBehaviour
{
    [Inject] private readonly BattleController _battle;

    public Action TimeKeyInvoke;
    
    [field: SerializeField] public float Speed { get; private set; }
    [SerializeField] private RythmSequence _sequence;

    public void OnObjectHit()
    {
        _battle.PlayerSideCombo.AddOne();
    }
    
    public void OnObjectMiss()
    {
        _battle.PlayerSideCombo.ResetCurrent();
    }

    public void OnKeyMiss()
    {
        _battle.PlayerSideCombo.ResetCurrent();
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
