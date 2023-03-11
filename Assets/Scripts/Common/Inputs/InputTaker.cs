using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputTaker : MonoBehaviour
{
    public Action<List<InputKey>> KeyUpdate;
    public Action KeyReset;

    private bool _isInputAvailable = true;
    private List<InputKey> _keys = new ();

    private Dictionary<KeyCode, InputKey> _keysCodes = new ()
    {
        {KeyCode.UpArrow, InputKey.Up},
        {KeyCode.LeftArrow, InputKey.Left},
        {KeyCode.RightArrow, InputKey.Right},
        {KeyCode.DownArrow, InputKey.Down}
    };
    

    private void Update()
    {
        if (_isInputAvailable && UpdateKeys())
        {
            KeyUpdate?.Invoke(_keys);
        };
    }

    public void ChangeInputAvailability(bool value) => _isInputAvailable = value;

    private bool UpdateKeys()
    {
        foreach (var keyValuePair in _keysCodes)
        {
            if (Input.GetKeyDown(keyValuePair.Key))
            {
                _keys.Add(keyValuePair.Value);
                return true;
            }
        }
        
        return false;
    }

    public void ResetKeys()
    {
        _keys.Clear();
        KeyReset?.Invoke();
    }
}
