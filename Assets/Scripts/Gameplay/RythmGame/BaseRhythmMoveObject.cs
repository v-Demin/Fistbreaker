using System;
using DG.Tweening;
using UnityEngine;

public class BaseRhythmMoveObject : MonoBehaviour
{
    [SerializeField] protected Ease _moveEase;

    [SerializeField] protected AbstractVisualObject _createdStateVisualObject;
    [SerializeField] protected AbstractVisualObject _activeStateVisualObject;
    [SerializeField] protected AbstractVisualObject _failedStateVisualObject;
    

    public virtual void ChangeActiveState(ActiveStateType value)
    {
        if (value == ActiveStateType.Created)
        {
            _createdStateVisualObject.Show();
        }
        else
        {
            _createdStateVisualObject.Hide();
        }
        
        if (value == ActiveStateType.Active)
        {
            _activeStateVisualObject.Show();
        }
        else
        {
            _activeStateVisualObject.Hide();
        }
        
        if (value == ActiveStateType.Failed)
        {
            _failedStateVisualObject.Show();
        }
        else
        {
            _failedStateVisualObject.Hide();
        }
    }

    public void Hide()
    {
        _createdStateVisualObject.Hide();
        _activeStateVisualObject.Hide();
        _failedStateVisualObject.Hide();
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
        Active = 1,
        Failed = 2
    }
}
