namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductVariant : AggregateRoot<long>
{
    public ProductQuantity Quantity { get; set; } = null!;  
    public Price Price { get; set; } = null!;
    public double DiscountedPercent { get; set; }
    public byte AvailabilityStatus { get; set; } 

    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public ICollection<ProductVariantOption> ProductVariantOptions { get; set; } = new HashSet<ProductVariantOption>();
}
