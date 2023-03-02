using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu]
public class BasePower : ScriptableObject
{
    //[Todo]: собрать в отдельный класс
    public string NameKey;
    public string DescriptionKey;

    
    [SerializeField] private List<FacetInfo> _facetsInfo;

    public void GetFacetViewInfos()
    {
        //[Todo]: информация для вьюшки
    }
    
    public void GetFacetInfos()
    {
        //[Todo]: информация об открытых/закрытых гранях силы
    }
    
    private void OnValidate()
    {
        _facetsInfo.ForEach(facet => facet.Rename());
        _facetsInfo.ForEach(facet => facet.ReId(_facetsInfo.IndexOf(facet)));
    }

    [System.Serializable]
    private class FacetInfo
    {
        [SerializeField] [HideInInspector] private string _name;
        [ReadOnly] public int Id;
        public AbstractFacet Facet;
        public string NameKey;
        public string DescriptionKey;

        public void ReId(int number)
        {
            Id = number;
        }

        public void Rename()
        {
            if(Facet == null) return;
            _name = Facet.name;
        }
    }
}
