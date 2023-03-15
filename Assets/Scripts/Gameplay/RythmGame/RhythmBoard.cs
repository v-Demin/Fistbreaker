using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using Zenject;

public class RhythmBoard : MonoBehaviour
{
    [Inject] private readonly RhythmGameplayController _rhythm;
    [Inject] private readonly InputTaker _input;

    [SerializeField] [Range(0.2f, 2.5f)] private float _distance;
    [SerializeField] [Range(-1f, 1f)] private float _offcet;
    [SerializeField] private RectTransform _endPoint;
    [SerializeField] private RectTransform _midPoint;
    [SerializeField] private RectTransform _startPoint;
    [SerializeField] private RhythmFactory _factory;

    private List<RhythmMoveObject> _rhythmObjects = new();

    private RhythmMoveObject LeftRhythmObject =>
        _rhythmObjects.OrderBy(obj => obj.transform.position.x).Take(1).First();

    private bool IsObjectHitMidpoint(Component obj) =>
        obj.transform.position.x <= _midPoint.position.x + _offcet + _distance &&
        obj.transform.position.x >= _midPoint.position.x + _offcet - _distance;
    
    private bool IsObjectMissMidpoint(Component obj) =>
        obj.transform.position.x <= _midPoint.position.x + _offcet - _distance;

    private void OnEnable()
    {
        _rhythm.TimeKeyInvoke += CreateNewObject;
        _input.KeyUpdate += keys => OnKeyUpdate();
    }

    private void OnDisable()
    {
        _rhythm.TimeKeyInvoke -= CreateNewObject;
        _input.KeyUpdate -= keys => OnKeyUpdate();
    }

    private void Update()
    {
        if (!_rhythmObjects.IsEmpty() && IsObjectMissMidpoint(LeftRhythmObject))
        {
            LeftRhythmObject.ChangeActiveState(RhythmMoveObject.ActiveStateType.Missed);
            _rhythmObjects.Remove(LeftRhythmObject);
            _rhythm.OnObjectMiss();
        }
    }

    private void OnKeyUpdate()
    {
        if (!_rhythmObjects.IsEmpty() && IsObjectHitMidpoint(LeftRhythmObject))
        {
            LeftRhythmObject.ChangeActiveState(RhythmMoveObject.ActiveStateType.Hit);
            _rhythmObjects.Remove(LeftRhythmObject);
            _rhythm.OnObjectHit();
        }
        else
        {
            _rhythm.OnKeyMiss();
        }
    }

    private void CreateNewObject()
    {
        var obj = _factory.CreateNewMoveObject(_startPoint);
        _rhythmObjects.Add(obj);
        obj.Move(_rhythm.Speed, _startPoint, _endPoint,
            () =>
            {
                _factory.ReturnToPool(obj);
                _rhythmObjects.Remove(obj);
            });
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.5f, 0.1f, 0.1f, 0.5f);
        Gizmos.DrawSphere(_midPoint.position.WithAddX(_offcet), _distance);
    }
}