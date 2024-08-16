namespace AppMicroServiceProduct.Application.Features.Products.Common;

public abstract class ProductVariantDto : BaseLongId
{
    private ProductVariantDto()
    {
        
    }
    public short Quantity { get; set; }
    public decimal Price { get; set; }
    public float DiscountedPercent { get; set; }
    public byte AvailabilityStatus { get; set; }

    public IEnumerable<ProductVariantOptionDto> ProductVariantOptions { get; set; } = Enumerable.Empty<ProductVariantOptionDto>();


    public class ProductVariantOptionDto
    {
        public long ProductVariantId { get; set; }

        public long VariantOptionId { get; set; }

        public long VariantOptionValueId { get; set; }
    }
}