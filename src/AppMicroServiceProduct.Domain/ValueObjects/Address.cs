namespace AppMicroServiceProduct.Domain.ValueObjects;

public class Address : BaseValueObject<Address>
{
    public Address()
    {
        ArgumentNullException.ThrowIfNull(No, "مقدار فیلد No وارد نشده است");
        ArgumentNullException.ThrowIfNull(Postalcode, "مقدار فیلد Postalcode وارد نشده است");
        ArgumentNullException.ThrowIfNull(AdditionalDescription, "مقدار فیلد AdditionalDescription وارد نشده است");
        if (StateId is 0)
            throw new InvalidDataException("Invalid StateId");
        if (CityId is 0)
            throw new InvalidDataException("CityId StateId");
    }

    public int Unit { get; set; }
    public int Floor { get; set; }
    public bool UserPinned { get; set; }

    public string No { get; set; } = null!;
    public string Postalcode { get; set; } = null!;
    public string AdditionalDescription { get; set; } = null!;
    public long StateId { get; set; }
    public long CityId { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Unit;
        yield return Floor;
        yield return UserPinned;
        yield return No;
        yield return Postalcode;
        yield return AdditionalDescription;
        yield return CityId;
    }
}
