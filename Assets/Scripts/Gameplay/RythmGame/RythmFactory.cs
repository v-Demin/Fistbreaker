using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class RythmFactory : MonoBehaviour
{
    [SerializeField] private RythmMoveObject _prefab;
    [SerializeField] private RectTransform _baseParent;

    private Queue<RythmMoveObject> _arrowsPool = new ();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ReturnToPool(CreateNewMoveObjectInner(_baseParent, false));
        }
    }

    public RythmMoveObject CreateNewMoveObject(RectTransform position)
    {
        return CreateNewMoveObjectInner(position);
    }

    private RythmMoveObject CreateNewMoveObjectInner(RectTransform position, bool takeFromPool = true)
    {
        var toReturn = _arrowsPool.IsEmpty() || !takeFromPool ? Instantiate(_prefab, position) : _arrowsPool.Dequeue();
        toReturn.gameObject.SetActive(true);
        toReturn.transform.SetParent(position);
        toReturn.transform.SetAsLastSibling();
        return toReturn;
    }

    public void ReturnToPool(RythmMoveObject arrow)
    {
        arrow.gameObject.SetActive(false);
        _arrowsPool.Enqueue(arrow);
    }
}
