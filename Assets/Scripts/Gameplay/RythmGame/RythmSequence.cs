using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Unity.Collections;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[CreateAssetMenu]
public class RythmSequence : ScriptableObject
{
    [SerializeField] [Range(0f, 23f)] private List<float> _info;
    [SerializeField] private float _timeToSeparate = 0.1f;
    private float SeparateValue => _timeToSeparate;

    public List<float> Timings => new(_info);

    #region Tech

    [Button(nameof(Separate))]
    private void Separate()
    {
        for (int i = 0; i < _info.Count - 1; i++)
        {
            if (_info[i + 1] - _info[i] < SeparateValue)
            {
                _info[i + 1] += SeparateValue;
                OnValidate();
            }
        }

        if (_info.Last() > 24f) _info[^1] = 24f;
    }

    [Button(nameof(Randomize))]
    private void Randomize()
    {
        for (int i = 0; i < _info.Count; i++)
        {
            _info[i] = UnityEngine.Random.Range(0f, 23f);
        }
        
        Separate();
        OnValidate();
    }

    private void OnValidate()
    {
        _info = _info.OrderBy(value => value).ToList();
        Separate();
    }

    #endregion
}
