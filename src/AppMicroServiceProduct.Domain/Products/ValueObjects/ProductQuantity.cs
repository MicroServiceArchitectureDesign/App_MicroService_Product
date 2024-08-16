namespace AppMicroServiceProduct.Domain.Products.ValueObjects;

public class ProductQuantity : BaseValueObject<ProductQuantity>
{
    public short Value { get; private set; } 

    public static ProductQuantity FromString(short value)
    {
        return new ProductQuantity(value);
    }

    private ProductQuantity(short value)
    {
        if (value < 0)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", "ProductQuantity", "0", "10000");
        }

        Value = value;
    }


    public static explicit operator short(ProductQuantity productName)
    {
        return productName.Value;
    }

    public static implicit operator ProductQuantity(short value)
    {
        return new ProductQuantity(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
