using System;
using DG.Tweening;
using UnityEngine;

public class SPTimer : MonoBehaviour
{
    public Action<float, float> OnTimeUpdated;
    public Action OnTimerStarted;
    public Action OnTimerEnded;

    private Tween _timerTween;
    
    public void StartTimer(float time, Action timerStartedAction = null, Action timerEndedAction = null)
    {
        _timerTween = DOVirtual.Float(0, time, time, value => OnTimeUpdated?.Invoke(time - value, value / time))
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

    public void Play()
    {
        _timerTween?.Play();
    }

    public void Pause()
    {
        _timerTween?.Pause();
    }

    public void Stop()
    {
        _timerTween?.Kill();
    }
}
