using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductVariantCreated : IDomainEvent
{
    public ProductVariantCreated(List<ProductVariant>  productVariants)
    {
        ProductVariants = productVariants;
    }

    public List<ProductVariant> ProductVariants { get; }
}