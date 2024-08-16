using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductUpdated : BaseProductEvent
{
    public long Id { get; set; }
    public ProductUpdated(long id,
        string name,
        string description,
        short quantity,
        decimal price,
        double discountedPercent,
        byte availabilityStatus,
        long categoryId,
        ProductWeightAndShipping? productWeightAndShipping)
    {
        Id = id;
        Name = name;
        Description = description;
        Quantity = quantity;
        Price = price;
        DiscountedPercent = discountedPercent;
        AvailabilityStatus = availabilityStatus;
        CategoryId = categoryId;
        ProductWeightAndShipping = productWeightAndShipping;
    }
}
