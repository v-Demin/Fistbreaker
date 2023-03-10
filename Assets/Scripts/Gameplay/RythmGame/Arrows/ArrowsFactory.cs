using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class ArrowsFactory : MonoBehaviour
{
    [SerializeField] private ArrowObject _prefab;
    [SerializeField] private RectTransform _baseParent;

    private Queue<ArrowObject> _arrowsPool = new ();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ReturnToPool(CreateNewArrowInner(_baseParent, false));
        }
    }

    public ArrowObject CreateNewArrow(RectTransform position)
    {
        return CreateNewArrowInner(position);
    }

    private ArrowObject CreateNewArrowInner(RectTransform position, bool takeFromPool = true)
    {
        var toReturn = _arrowsPool.IsEmpty() || !takeFromPool ? Instantiate(_prefab, position) : _arrowsPool.Dequeue();
        toReturn.gameObject.SetActive(true);
        toReturn.transform.SetParent(position);
        toReturn.transform.SetAsLastSibling();
        return toReturn;
    }

    public void ReturnToPool(ArrowObject arrow)
    {
        arrow.gameObject.SetActive(false);
        _arrowsPool.Enqueue(arrow);
    }
}