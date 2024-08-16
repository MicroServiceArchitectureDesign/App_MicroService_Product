namespace AppMicroServiceProduct.Domain.Products.Entities;

public class VariantOption : AggregateRoot<long>
{
    public string Title { get; set; } = null!;
    public ICollection<VariantOptionValue> VariantOptionValues { get; set; } = new HashSet<VariantOptionValue>();
    public ICollection<ProductVariantOption> ProductVariantOptions { get; set; } = new HashSet<ProductVariantOption>();
}
