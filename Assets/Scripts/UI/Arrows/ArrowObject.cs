using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _moveEase;
    [SerializeField] private Ease _scaleEase;

    [SerializeField] private GameObject _passiveStateRoot;
    [SerializeField] private GameObject _activeStateRoot;
    
    [SerializeField] private GameObject _leftDirectionRoot;
    [SerializeField] private GameObject _upDirectionRoot;
    [SerializeField] private GameObject _rightDirectionRoot;
    [SerializeField] private GameObject _downDirectionRoot;

    [SerializeField] private AnimationCurve _activeStateScaleCurve;
    [SerializeField] private AnimationCurve _passiveStateScaleCurve;
    
    public void Init(bool isActiveState, InputKey direction)
    {
        _passiveStateRoot.SetActive(!isActiveState);
        _activeStateRoot.SetActive(isActiveState);
        
        _leftDirectionRoot.SetActive(direction == InputKey.Left);
        _upDirectionRoot.SetActive(direction == InputKey.Up);
        _rightDirectionRoot.SetActive(direction == InputKey.Right);
        _downDirectionRoot.SetActive(direction == InputKey.Down);
    }
    
    public void PlayAnimation(RectTransform startPosition, RectTransform endPosition, bool isActiveState, Action onComplete = null)
    {
        transform.position = startPosition.position;

        var curve = isActiveState ? _activeStateScaleCurve : _passiveStateScaleCurve;

        DOTween.To(() => 0f, value => transform.localScale = Vector3.one * curve.Evaluate(value), 1f, _duration)
            .SetEase(_scaleEase);
        
        transform.DOMove(endPosition.position, _duration)
            .SetEase(_moveEase)
            .OnComplete(() => onComplete?.Invoke());
    }
}
