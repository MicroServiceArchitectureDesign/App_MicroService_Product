namespace AppMicroServiceProduct.Domain.ValueObjects;
public class PersonName : BaseValueObject<PersonName>
{
    public PersonName() { }
    public PersonName(string firstName, string lastName)
    {
        if (firstName.Length > 50)
            throw new InvalidDataException("عدم رعایت محدودیت، نام فقط می تواند شامل 50 کارکتر باشد");
        if (firstName.Length > 50)
            throw new InvalidDataException("عدم رعایت محدودیت، نام خانوادگی فقط می تواند شامل 50 کارکتر باشد");

        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public string ReverseFullName => $"{LastName} {FirstName}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return FullName;
        yield return ReverseFullName;
    }
}
