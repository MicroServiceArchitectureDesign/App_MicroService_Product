namespace AppMicroServiceProduct.Domain.Products.ValueObjects;

public class Price : BaseValueObject<Price>
{
    private Price() { }

    public decimal Value { get; private set; } 

    public static Price FromString(decimal value)
    {
        return new Price(value);
    }

    public Price(decimal value)
    {
        if (value < 10000)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", "Price", "10000");
        }

        Value = value;
    }

    public static explicit operator decimal(Price productName)
    {
        return productName.Value;
    }

    public static implicit operator Price(decimal value)
    {
        return new Price(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
