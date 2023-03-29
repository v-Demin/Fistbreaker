using DG.Tweening;
using UnityEngine;

public class ScaleVisualEvaluateObject : ScaleVisualObject
{
    protected override Tween ShowInner(bool fast = false)
    {
        return DOTween.To(() => 0f, value => transform.localScale = Vector3.one * _showCurve.Evaluate(value), 1f, _showTime)
            .SetEase(_showEase);
    }

    protected override Tween HideInner(bool fast = false)
    {
        return DOTween.To(() => 0f, value => transform.localScale = Vector3.one * _hideCurve.Evaluate(value), 1f, _hideTime)
            .SetEase(_hideEase);
    }
}
