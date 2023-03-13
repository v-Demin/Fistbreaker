using System;
using DG.Tweening;
using UnityEngine;

public class RhythmMoveObject : MonoBehaviour
{
    [SerializeField] private Ease _moveEase;

    [SerializeField] private AbstractVisualObject _createdStateVisualObject;
    [SerializeField] private AbstractVisualObject _hitStateVisualObject;
    [SerializeField] private AbstractVisualObject _missedStateVisualObject;
    

    public void ChangeActiveState(ActiveStateType value)
    {
        if (value == ActiveStateType.Created)
        {
            _createdStateVisualObject.Show();
        }
        else
        {
            _createdStateVisualObject.Hide();
        }
        
        if (value == ActiveStateType.Hit)
        {
            _hitStateVisualObject.Show();
        }
        else
        {
            _hitStateVisualObject.Hide();
        }
        
        if (value == ActiveStateType.Missed)
        {
            _missedStateVisualObject.Show();
        }
        else
        {
            _missedStateVisualObject.Hide();
        }
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
