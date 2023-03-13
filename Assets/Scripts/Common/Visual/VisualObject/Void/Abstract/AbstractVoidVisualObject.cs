using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVoidVisualObject : AbstractVisualObject
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

        ShowInner(fast);
        ChangeObjectActivity(true);

    }

    protected abstract void ShowInner(bool fast = false);

    public override void Hide(bool fast)
    {
        if (!this.enabled) return;

        HideInner(fast);
        ChangeObjectActivity(false);
    }

    protected abstract void HideInner(bool fast = false);
}
