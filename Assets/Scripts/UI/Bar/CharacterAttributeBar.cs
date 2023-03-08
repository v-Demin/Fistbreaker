using DG.Tweening;
using UnityEngine;

public class CharacterAttributeBar : BaseViewBar
{
    [SerializeField] private Color _damegeColor;
    [SerializeField] private Color _healColor;
    private float _lastValue = 0;
    private Tween _barTween;
    
    public void ShowInfo(float currentValue, float maxValue)
    {
        _barTween.Kill();
        _barTween = DOVirtual.Float(_lastValue, currentValue, 0.3f, value =>
        {
            _lastValue = value;
            UpdateBar(1 - value / maxValue);
            UpdateText($"{value:0}/{maxValue:0}");
        })
            .SetEase(Ease.OutQuart);
    }
}
