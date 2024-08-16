using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class BaseProductEvent : IDomainEvent
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public short Quantity { get; set; }
    public decimal Price { get; set; }
    public double DiscountedPercent { get; set; }
    public byte AvailabilityStatus { get; set; }

    public long CategoryId { get; set; }

    public ProductWeightAndShipping? ProductWeightAndShipping { get; set; }
}
