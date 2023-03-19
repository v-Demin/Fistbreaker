using UnityEngine;
using Zenject;

public class Bio
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public SexType Sex { get; private set; }
    public GenderType Gender { get; private set; }
    
    [Inject]
    public Bio(NameGenerator generator)
    {
        FirstName = generator.GetFirstName();
        LastName = generator.GetLastName();
        Age = Random.Range(18, 40);
        Sex = (SexType)Random.Range(0,2);
        Gender = (GenderType)Random.Range(0,3);
    }
    
    public Bio(string firstName, string lastName, int age, SexType sex, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        Sex = sex;
    }
    
    public enum SexType
    {
        Male = 0,
        Female = 1
    }
    
    public enum GenderType
    {
        Male = 0,
        Female = 1,
        Other = 2
    }
}
