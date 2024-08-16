namespace AppMicroServiceProduct.Application.Features.Products.Common;

public class BaseCreateUpdateProductCommand : BaseLongId, ICommandRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public short Quantity { get; set; }
    public decimal Price { get; set; }
    public float DiscountedPercent { get; set; }
    public byte AvailabilityStatus { get; set; }
    public required ProductWeightAndShippingDTO ProductWeightAndShipping { get; set; }

    public long CategoryId { get; set; }
    public IEnumerable<long> SubCategories { get; } = Enumerable.Empty<long>();
}