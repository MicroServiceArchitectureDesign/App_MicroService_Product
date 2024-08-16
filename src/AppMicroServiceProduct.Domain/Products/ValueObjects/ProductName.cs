namespace AppMicroServiceProduct.Domain.Products.ValueObjects;

public class ProductName : BaseValueObject<ProductName>
{
    private ProductName() { }


    public string Value { get; private set; } = string.Empty;

    public static ProductName FromString(string value)
    {
        return new ProductName(value);
    }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", "ProductName");
        }

        if (value.Length < 2 || value.Length > 250)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", "ProductName", "2", "250");
        }

        Value = value;
    }

    public static explicit operator string(ProductName productName)
    {
        return productName.Value;
    }

    public static implicit operator ProductName(string value)
    {
        return new ProductName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
