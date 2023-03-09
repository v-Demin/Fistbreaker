using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ArrowsView : MonoBehaviour
{
    [Inject] private readonly InputTaker _inputTaker;

    [SerializeField] private ArrowsFactory _factory;
    [SerializeField] private RectTransform _startPosition;
    [SerializeField] private RectTransform _endPosition;
    
    private void OnEnable()
    {
        _inputTaker.OnKeyUpdate += keys => ShowArrows(keys.Last());
    }

    private void OnDisable()
    {
        _inputTaker.OnKeyUpdate -= keys => ShowArrows(keys.Last());
    }

    private void ShowArrows(InputKey key)
    {
        var arrow = _factory.CreateNewArrow(_startPosition);
        arrow.Init(false, key);
        arrow.PlayAnimation(_startPosition, _endPosition, false, () => _factory.ReturnToPool(arrow));
    }
}