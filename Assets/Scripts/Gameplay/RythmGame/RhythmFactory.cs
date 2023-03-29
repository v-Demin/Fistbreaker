using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class RhythmFactory : MonoBehaviour
{
    [SerializeField] private BaseRhythmMoveObject _prefab;
    [SerializeField] private RectTransform _baseParent;

    private Queue<BaseRhythmMoveObject> _arrowsPool = new ();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ReturnToPool(CreateNewMoveObjectInner(_baseParent, false));
        }
    }

    public BaseRhythmMoveObject CreateNewMoveObject(RectTransform position)
    {
        return CreateNewMoveObjectInner(position);
    }

    private BaseRhythmMoveObject CreateNewMoveObjectInner(RectTransform position, bool takeFromPool = true)
    {
        var toReturn = _arrowsPool.IsEmpty() || !takeFromPool ? Instantiate(_prefab, position) : _arrowsPool.Dequeue();
        toReturn.gameObject.SetActive(true);
        toReturn.transform.SetParent(position);
        toReturn.transform.SetAsLastSibling();
        toReturn.ChangeActiveState(BaseRhythmMoveObject.ActiveStateType.Created);
        return toReturn;
    }

    public void ReturnToPool(BaseRhythmMoveObject arrow)
    {
        arrow.gameObject.SetActive(false);
        _arrowsPool.Enqueue(arrow);
    }
}
