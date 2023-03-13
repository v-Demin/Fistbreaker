using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AlphaUIVisualObject : AbstractTweenVisualObject
{
    [SerializeField] private float _showTime;
    [SerializeField] private float _showAlpha;
    [SerializeField] private Ease _showEase;

    [SerializeField] private float _hideTime;
    [SerializeField] private float _hideAlpha;
    [SerializeField] private Ease _hideEase;

    [SerializeField] private List<Image> _images;

    private List<Tween> _tweens = new ();

    protected override Tween ShowInner(bool fast = false)
    {
        _tweens.ForEach(tween => tween.Kill());
        
        _images.ForEach(image => 
            _tweens.Add(
                image.DOFade(_showAlpha, CheckTime(_showTime, 0f, fast))
                    .SetEase(_showEase)));

        return EmptyTween(CheckTime(_showTime, 0f, fast));
    }

    protected override Tween HideInner(bool fast = false)
    {
        _tweens.ForEach(tween => tween.Kill());
        
        _images.ForEach(image => 
            _tweens.Add(
                image.DOFade(_hideAlpha, CheckTime(_hideTime, 0f, fast))
                    .SetEase(_hideEase)));
        
        return EmptyTween(CheckTime(_hideTime, 0f, fast));
    }
}
