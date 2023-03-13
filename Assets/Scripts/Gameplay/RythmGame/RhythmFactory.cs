using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class RhythmFactory : MonoBehaviour
{
    [SerializeField] private RhythmMoveObject _prefab;
    [SerializeField] private RectTransform _baseParent;

    private Queue<RhythmMoveObject> _arrowsPool = new ();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ReturnToPool(CreateNewMoveObjectInner(_baseParent, false));
        }
    }

    public RhythmMoveObject CreateNewMoveObject(RectTransform position)
    {
        return CreateNewMoveObjectInner(position);
    }

    private RhythmMoveObject CreateNewMoveObjectInner(RectTransform position, bool takeFromPool = true)
    {
        var toReturn = _arrowsPool.IsEmpty() || !takeFromPool ? Instantiate(_prefab, position) : _arrowsPool.Dequeue();
        toReturn.gameObject.SetActive(true);
        toReturn.transform.SetParent(position);
        toReturn.transform.SetAsLastSibling();
        toReturn.ChangeActiveState(RhythmMoveObject.ActiveStateType.Created);
        return toReturn;
    }

    public void ReturnToPool(RhythmMoveObject arrow)
    {
        arrow.gameObject.SetActive(false);
        _arrowsPool.Enqueue(arrow);
    }
}
