using System;
using DG.Tweening;
using UnityEngine;

public class SPTimer : MonoBehaviour
{
    public Action<float, float> OnTimeUpdated;
    public Action OnTimerStarted;
    public Action OnTimerEnded;

    public void StartTimer(float time, Action timerStartedAction = null, Action timerEndedAction = null)
    {
        DOVirtual.Float(0, time, time, value => OnTimeUpdated?.Invoke(time - value, value / time))
            .SetEase(Ease.Linear)
            .OnStart(() =>
            {
                OnTimerStarted?.Invoke();
                timerStartedAction?.Invoke();
            })
            .OnComplete(() =>
            {
                OnTimerEnded?.Invoke();
                timerEndedAction?.Invoke();
            });
    }
}
