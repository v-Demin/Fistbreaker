using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class ScaleVisualObject : AbstractTweenVisualObject
{
    [SerializeField] protected float _showTime;
    [SerializeField] protected float _showScale;
    [SerializeField] protected ShowType _showType;
    [SerializeField] [ShowIf("_showType", ShowType.Ease)] protected Ease _showEase;
    [SerializeField] [ShowIf("_showType", ShowType.AnimationCurve)] protected AnimationCurve _showCurve;

    [SerializeField] protected float _hideTime;
    [SerializeField] protected float _hideScale;
    [SerializeField] protected ShowType _hideType;
    [SerializeField] [ShowIf("_hideType", ShowType.Ease)] protected Ease _hideEase;
    [SerializeField] [ShowIf("_hideType", ShowType.AnimationCurve)] protected AnimationCurve _hideCurve;


    
    protected override Tween ShowInner(bool fast = false)
    {
        var toReturn = transform.DOScale(_showScale, GetTweenTime(_showTime, 0f, fast));

        switch (_showType)
        {
            case ShowType.Ease:
                toReturn.SetEase(_showEase);
                break;
            case ShowType.AnimationCurve:
                toReturn.SetEase(_showCurve);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return toReturn;
    }

    protected override Tween HideInner(bool fast = false)
    {
        var toReturn = transform.DOScale(_hideScale, GetTweenTime(_hideTime, 0f, fast));
        
        switch (_hideType)
        {
            case ShowType.Ease:
                toReturn.SetEase(_hideEase);
                break;
            case ShowType.AnimationCurve:
                toReturn.SetEase(_hideCurve);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return toReturn;
    }
    
    protected enum ShowType
    {
        Ease = 0,
        AnimationCurve = 1
    }
}
