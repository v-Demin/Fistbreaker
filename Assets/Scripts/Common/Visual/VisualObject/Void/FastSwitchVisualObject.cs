using DG.Tweening;
using UnityEngine;

public class FastSwitchVisualObject : AbstractVoidVisualObject
{
    [SerializeField] private GameObject _root;
    
    protected override void ShowInner(bool fast = false)
    {
        _root.SetActive(true);
    }

    protected override void HideInner(bool fast = false)
    {
        _root.SetActive(false);
    }
}
