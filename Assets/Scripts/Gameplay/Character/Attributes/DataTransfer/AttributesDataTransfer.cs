public class AttributesDataTransfer
{
    public CharacteristicContainer Characteristics;
    public Attributes StartAttributes; 
    public MaxAttributes MaxAttributes; 
        
    public AttributesDataTransfer(CharacteristicContainer characteristic, MaxAttributes maxAttributes) :
        this(characteristic, new Attributes(maxAttributes), maxAttributes)
    {
    }
    
    public AttributesDataTransfer(CharacteristicContainer characteristic, Attributes startAttributes, MaxAttributes maxAttributes)
    {
        Characteristics = characteristic;
        StartAttributes = startAttributes;
        MaxAttributes = maxAttributes;
    }
}
