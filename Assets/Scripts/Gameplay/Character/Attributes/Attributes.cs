using System.Linq;
using System.Reflection;
using UnityEngine;

public class Attributes
{
    public float Health { get; private set; }
    public float Sp { get; private set; }

    public Attributes(float health, float sp)
    {
        Health = health;
        Sp = sp;
    }

    public static Attributes Clamp(Attributes attributes, Attributes maxValues)
    {
        return new Attributes(
            Mathf.Clamp(attributes.Health, 0, maxValues.Health),
            Mathf.Clamp(attributes.Sp, 0, maxValues.Sp));
    }
    
    public static Attributes operator +(Attributes a, Attributes b)
    {
        return new Attributes(a.Health + b.Health, a.Sp + b.Sp);
    }
}
