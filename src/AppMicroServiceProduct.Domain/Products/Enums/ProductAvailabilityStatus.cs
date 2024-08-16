namespace AppMicroServiceProduct.Domain.Products.Enums;

public record ProductAvailabilityStatus : BaseEnumeration<ProductAvailabilityStatus>
{
    public new byte Value { get; }

    private ProductAvailabilityStatus(byte value, string displayName)
        : base(value, displayName)
    {
        Value = value;
    }

    public static ProductAvailabilityStatus Unavailable = new(1, "ناموجود");
    public static ProductAvailabilityStatus Available = new(2, "موجود");
}