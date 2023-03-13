using NaughtyAttributes;
using UnityEngine;

public abstract class AbstractVisualObject : MonoBehaviour
{
    [SerializeField] protected bool _isChangingOnStart = true;
    [SerializeField] [ShowIf("_isChangingOnStart")] protected bool _isShowedOnStart = false;
    [SerializeField] private bool _isChangingActivityOnShowOrHide = true;


    public abstract void Show(bool fast = false);
    public abstract void Hide(bool fast = false);
    
    protected float CheckTime(float bigTime, float fastTime, bool isFast) => isFast ? fastTime : bigTime;

    protected void ChangeObjectActivity(bool value)
    {
        if (_isChangingActivityOnShowOrHide)
        {
            gameObject.SetActive(value);
        }
    }
}
