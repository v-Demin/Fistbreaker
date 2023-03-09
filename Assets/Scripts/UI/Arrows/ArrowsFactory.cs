using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

public class ArrowsFactory : MonoBehaviour
{
    [SerializeField] private ArrowObject _prefab;

    private Queue<ArrowObject> _arrowsPool = new ();

    public ArrowObject CreateNewArrow(RectTransform position)
    {
        var toReturn = _arrowsPool.IsEmpty() ? Instantiate(_prefab, position) : _arrowsPool.Dequeue();
        toReturn.gameObject.SetActive(true);
        toReturn.transform.SetAsLastSibling();
        return toReturn;
    }

    public void ReturnToPool(ArrowObject arrow)
    {
        arrow.gameObject.SetActive(false);
        _arrowsPool.Enqueue(arrow);
    }
}