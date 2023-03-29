using System;
using DG.Tweening;
using UnityEngine;

public class ArrowObject : BaseRhythmMoveObject
{
    [SerializeField] private AbstractVisualObject _leftDirectionRoot;
    [SerializeField] private AbstractVisualObject _upDirectionRoot;
    [SerializeField] private AbstractVisualObject _rightDirectionRoot;
    [SerializeField] private AbstractVisualObject _downDirectionRoot;
    
    public void ShowArrow(InputKey direction)
    {
        HideArrows(true);
        
        if (direction == InputKey.Down) _downDirectionRoot.Show();
        if (direction == InputKey.Up) _upDirectionRoot.Show();
        if (direction == InputKey.Right) _rightDirectionRoot.Show();
        if (direction == InputKey.Left) _leftDirectionRoot.Show();
    }

    public void HideArrows(bool fast)
    {
        _downDirectionRoot.Hide(fast);
        _upDirectionRoot.Hide(fast);
        _rightDirectionRoot.Hide(fast);
        _leftDirectionRoot.Hide(fast);
    }
}
