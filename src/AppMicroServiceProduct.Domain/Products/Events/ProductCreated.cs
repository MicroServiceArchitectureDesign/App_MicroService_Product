using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductCreated : BaseProductEvent
{
    public ProductCreated(string name,
        string description,
        short quantity,
        decimal price,
        double discountedPercent,
        byte availabilityStatus,
        long categoryId,
        ProductWeightAndShipping? productWeightAndShipping)
    {
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
