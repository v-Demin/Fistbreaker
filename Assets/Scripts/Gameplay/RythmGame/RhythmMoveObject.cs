using System;
using DG.Tweening;
using UnityEngine;

public class RhythmMoveObject : MonoBehaviour
{
    [SerializeField] private Ease _moveEase;

    [SerializeField] private GameObject _createdStateRoot;
    [SerializeField] private GameObject _hitStateRoot;
    [SerializeField] private GameObject _missedStateRoot;
    

    public void ChangeActiveState(ActiveStateType value)
    {
        _createdStateRoot.SetActive(value == ActiveStateType.Created);
        _hitStateRoot.SetActive(value == ActiveStateType.Hit);
        _missedStateRoot.SetActive(value == ActiveStateType.Missed);
    }
    
    public void Move(float speed, RectTransform startPosition, RectTransform endPosition, Action onComplete = null)
    {
        transform.position = startPosition.position;

        transform.DOMove(endPosition.position, speed)
            .SetEase(_moveEase)
            .SetSpeedBased()
            .OnComplete(() => onComplete?.Invoke());
    }
    
    public enum ActiveStateType
    {
        Created = 0,
        Hit = 1,
        Missed = 2
    }
}
