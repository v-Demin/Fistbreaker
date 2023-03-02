using System.Collections.Generic;

public class PowerContainer
{
    private readonly AttributesContainer _attributes;
    
    private BasePower _power;
    private List<int> _openedFacetsIds;

    private float PowerModifier => _attributes.PowerModifyer;
    
    public PowerContainer(AttributesContainer attributes)
    {
        _attributes = attributes;
    }
}
