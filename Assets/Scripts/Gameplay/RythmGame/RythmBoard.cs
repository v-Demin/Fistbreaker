using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class RythmBoard : MonoBehaviour
{
    [Inject] private readonly RythmGameplayController _rythm;
    
    [SerializeField] [Range(0.5f, 2.5f)] private float _distance;
    [SerializeField] private RectTransform _endPoint;
    [SerializeField] private RectTransform _midPoint;
    [SerializeField] private RectTransform _startPoint;
    [SerializeField] private RythmSequence _sequence;
    [SerializeField] private RythmFactory _factory;
    
    private void Start()
    {
        var sequence = DOTween.Sequence();
        _sequence.Timings.ForEach(value =>
        {
            sequence.InsertCallback(value, () =>
            {
                var moveObject = _factory.CreateNewMoveObject(_startPoint);
                moveObject.Move(_rythm.Speed, _startPoint, _endPoint, () => _factory.ReturnToPool(moveObject));
            });
        });
    }

    private void OnDrawGizmosSelected()
    {
        $"_midPoint.position.x - _distance {_midPoint.position.x - _distance}".Log(Color.blue);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_midPoint.position, _distance);
    }
}
