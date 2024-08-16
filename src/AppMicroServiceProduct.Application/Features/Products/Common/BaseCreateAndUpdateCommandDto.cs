namespace AppMicroServiceProduct.Application.Features.Products.Common;

public class BaseCreateAndUpdateCommandDto : BaseLongId
{
    public required string Name { get; set; } 
    public required string Description { get; set; } 
    public short Quantity { get; set; }
    public decimal Price { get; set; }
    public float DiscountedPercent { get; set; }
    public byte AvailabilityStatus { get; set; } 
    public required ProductWeightAndShippingDTO ProductWeightAndShipping { get; set; } 

    public long CategoryId { get; set; }

    public List<long> SubCategories { get; set; }  = new();
    public List<ProductVariantDto> Variants { get; set; } = new();
    public List<ProductImageDto> Images { get; set; } = new();
    public List<ProductVideoDto> Videos { get; set; } = new();
    public List<ProductPropertyDto> Properties { get; set; } = new();
}