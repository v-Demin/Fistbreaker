using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VisualObjectContainer : AbstractVoidVisualObject
{
    [SerializeField] private List<AbstractVisualObject> _visualObjects;
    protected override void ShowInner(bool fast = false)
    {
        _visualObjects.ForEach(obj => obj.Show(fast));
    }

    protected override void HideInner(bool fast = false)
    {
        _visualObjects.ForEach(obj => obj.Hide(fast));
    }
}
