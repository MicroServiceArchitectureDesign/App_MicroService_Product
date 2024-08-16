namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductVariantOption : LongEntity
{
    public long ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; } = null!;

    public long VariantOptionId { get; set; }
    public VariantOption VariantOption { get; set; } = null!;

    public long VariantOptionValueId { get; set; }
    public VariantOptionValue VariantOptionValue { get; set; } = null!;
}
