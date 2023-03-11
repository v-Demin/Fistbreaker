using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ArrowsView : MonoBehaviour
{
    [Inject] private readonly InputTaker _inputTaker;
    [Inject] private readonly RhythmGameplayController _rhythm;

    [SerializeField] private ArrowsFactory _factory;
    [SerializeField] private RectTransform _arrowSpawnPosition;
    [SerializeField] private RectTransform _arrowDespawnPosition;
    
    private void OnEnable()
    {
        _inputTaker.KeyUpdate += keys => ShowArrows(keys.Last());
    }

    private void OnDisable()
    {
        _inputTaker.KeyUpdate -= keys => ShowArrows(keys.Last());
    }

    private void ShowArrows(InputKey key)
    {
        var arrow = _factory.CreateNewArrow(_arrowSpawnPosition);
        arrow.Init(false, key);
        arrow.Move(_rhythm.Speed, _arrowSpawnPosition, _arrowDespawnPosition, false, () => _factory.ReturnToPool(arrow));
    }
}
