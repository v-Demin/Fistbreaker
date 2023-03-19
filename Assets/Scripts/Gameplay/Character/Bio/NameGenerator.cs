using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    [SerializeField] protected List<string> BaseFirstNames;
    [SerializeField] protected List<string> BaseLastNames;
    [SerializeField] protected List<string> BaseWords;

    public string GetFirstName()
    {
        return BaseFirstNames[Random.Range(0, BaseFirstNames.Count)];
    }

    public string GetLastName()
    {
        return BaseLastNames[Random.Range(0, BaseLastNames.Count)];
    }
}
