using System;
using System.Collections.Generic;
using UnityEngine;

public class BasePower : ScriptableObject
{
    private const float BASE_POWER_BONUS = 1.2f;

    private float _additionalPowerBonus = 0f;
    protected readonly Balance Balance;
    [SerializeField] private List<FacetInfo> _facetsInfo;

    public float AdditionalPower => BASE_POWER_BONUS * Balance.Value;

    public BasePower(ref Balance balance)
    {
        Balance = balance;
    }

    private void OnValidate()
    {
        _facetsInfo.ForEach(facet => facet.Rename());
    }

    [System.Serializable]
    private class FacetInfo
    {
        [SerializeField] [HideInInspector] private string _name;
        public AbstractFacet Facet;
        public string NameKey;
        public string DescriptionKey;

        public void Rename()
        {
            if(Facet == null) return;
            _name = Facet.name;
        }
    }
}
