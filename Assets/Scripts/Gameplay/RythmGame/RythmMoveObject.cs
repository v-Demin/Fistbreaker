using System;
using DG.Tweening;
using UnityEngine;

public class RythmMoveObject : MonoBehaviour
{
    [SerializeField] private Ease _moveEase;

    [SerializeField] private GameObject _passiveStateRoot;
    [SerializeField] private GameObject _activeStateRoot;
    

    public void ChangeActiveState(bool value = true)
    {
        _passiveStateRoot.SetActive(!value);
        _activeStateRoot.SetActive(value);
    }
    
    public void Move(float speed, RectTransform startPosition, RectTransform endPosition, Action onComplete = null)
    {
        transform.position = startPosition.position;

        transform.DOMove(endPosition.position, speed)
            .SetEase(_moveEase)
            .SetSpeedBased()
            .OnComplete(() => onComplete?.Invoke());
    }
}
