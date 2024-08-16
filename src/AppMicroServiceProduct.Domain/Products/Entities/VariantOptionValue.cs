namespace AppMicroServiceProduct.Domain.Products.Entities;

public class VariantOptionValue : LongEntity
{
    public string Title { get; set; } = null!;

    public long VariantOptionId { get; set; }
    public VariantOption VariantOption { get; set; } = null!;
    public ICollection<ProductVariant> ProductVariants { get; set; } = new HashSet<ProductVariant>();
    public ICollection<ProductVariantOption> ProductVariantOptions { get; set; } = new HashSet<ProductVariantOption>();
}
