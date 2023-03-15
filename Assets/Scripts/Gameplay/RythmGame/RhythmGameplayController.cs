using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class RhythmGameplayController : MonoBehaviour
{
    [Inject] private readonly BattleController _battle;

    public Action TimeKeyInvoke;
    
    [field: SerializeField] public float Speed { get; private set; }
    [SerializeField] private RythmSequence _rythmSequence;
    private Sequence _tweenSequence;
    
    public void StartGameplay()
    {
        _tweenSequence = DOTween.Sequence();
        _rythmSequence.Timings.ForEach(value =>
        {
            _tweenSequence.InsertCallback(value, () => TimeKeyInvoke?.Invoke());
        });
    }

    public void EndGameplay()
    {
        _tweenSequence?.Kill();
    }

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
}
