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
        $"Попел".Log(Color.red);
        _battle.PlayerSideCombo.AddOne();
    }
    
    public void OnObjectMiss()
    {
        $"Пропустил".Log(Color.red);
        _battle.PlayerSideCombo.ResetToLastMax();
    }

    public void OnKeyMiss()
    {
        $"Акелла промахнулся".Log(Color.red);
        _battle.PlayerSideCombo.ResetToLastMax();
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
