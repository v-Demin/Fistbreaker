using NaughtyAttributes;
using TMPro.EditorUtilities;
using UnityEngine;

public class RythmBoardRepositionHelper : MonoBehaviour
{
    [SerializeField] [ReadOnly] private float _localDistance;
    [SerializeField] [Range(0f, 1f)] private float _middleReposition;

    [SerializeField] private RectTransform _startPosition;
    [SerializeField] private RectTransform _middlePosition;
    [SerializeField] private RectTransform _endPosition;
    
    private void OnValidate()
    {
        _localDistance = Vector3.Magnitude(_endPosition.position - _startPosition.position);
        _middlePosition.position = new Vector3(_startPosition.position.x - _localDistance * (1 - _middleReposition), _startPosition.position.y, _startPosition.position.z);
    }
}
