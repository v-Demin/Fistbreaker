using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class AbstractTweenVisualObject : AbstractVisualObject
{
    protected virtual void Start()
    {
        if (_isChangingOnStart)
        {
            if (_isShowedOnStart)
            {
                ShowInner(true);
            }
            else
            {
                HideInner(true);
            }
        }
    }

    public override void Show(bool fast)
    {
        if (!this.enabled) return;
        
        ShowInner(fast)
            .OnStart(() => { ChangeObjectActivity(true); });
    }
    
    protected abstract Tween ShowInner(bool fast = false);

    public override void Hide(bool fast)
    {
        if (!this.enabled) return;

        HideInner(fast)
            .OnComplete(() => { ChangeObjectActivity(false); });
    }
    
    protected abstract Tween HideInner(bool fast = false);

    protected Tween EmptyTween(float time) => DOVirtual.DelayedCall(time, () => { });
}
