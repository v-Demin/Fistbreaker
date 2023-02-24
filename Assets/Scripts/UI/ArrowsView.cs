using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class ArrowsView : MonoBehaviour
{
    [Inject] private readonly InputTaker _inputTaker;

    [SerializeField] private RectTransform _content;
    [SerializeField] private TextMeshProUGUI _text;

    private Tween _resetTween;

    private Dictionary<InputKey, string> _container = new Dictionary<InputKey, string>()
    {
        {InputKey.Up, "↑"},
        {InputKey.Right, "→"},
        {InputKey.Left, "←"},
        {InputKey.Down, "↓"}
    };

    private void OnEnable()
    {
        _inputTaker.OnKeyUpdate += ShowArrows;
    }

    private void OnDisable()
    {
        _inputTaker.OnKeyUpdate -= ShowArrows;
    }

    private void ShowArrows(List<InputKey> keys)
    {
        _resetTween.Kill(false);
        _text.text += _container[keys.Last()];
        if (_text.text.Length > 5) _text.text = _text.text[1..];
    }
}
