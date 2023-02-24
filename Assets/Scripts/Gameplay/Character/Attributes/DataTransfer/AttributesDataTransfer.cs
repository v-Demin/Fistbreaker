public class AttributesDataTransfer
{
    public CharacteristicContainer Characteristics;
    public ExperienceContainer Experiences; 
    public Attributes StartAttributes; 
    public Attributes MaxAttributes; 
        
    public AttributesDataTransfer(CharacteristicContainer characteristic, ExperienceContainer experiences, Attributes startAttributes, Attributes maxAttributes)
    {
        Characteristics = characteristic;
        Experiences = experiences;
        StartAttributes = startAttributes;
        MaxAttributes = maxAttributes;
    }
}
