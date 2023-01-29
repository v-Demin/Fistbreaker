using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputTaker : MonoBehaviour
{
    public Action<List<InputKey>> OnKeyUpdate;
    
    private List<InputKey> _keys = new List<InputKey>();

    private Dictionary<KeyCode, InputKey> _keysCodes = new Dictionary<KeyCode, InputKey>()
    {
        {KeyCode.UpArrow, InputKey.Up},
        {KeyCode.LeftArrow, InputKey.Left},
        {KeyCode.RightArrow, InputKey.Right},
        {KeyCode.DownArrow, InputKey.Down}
    };

    private void Update()
    {
        if (UpdateKeys())
        {
            OnKeyUpdate?.Invoke(_keys);
        };
    }

    private bool UpdateKeys()
    {
        foreach (var keyValuePair in _keysCodes)
        {
            if (Input.GetKeyDown(keyValuePair.Key))
            {
                $"Добавляем: {keyValuePair.Value}".Log(Color.cyan);
                _keys.Add(keyValuePair.Value);
                return true;
            }
        }
        
        return false;
    }

    public void ResetKeys()
    {
        "Сбрасываем кнопки".Log(Color.black);
        _keys.Clear();
    }
}
