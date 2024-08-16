using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductPropertyCreated : IDomainEvent
{
    public ProductPropertyCreated(List<ProductProperty>  productProperties)
    {
        ProductProperties = productProperties;
    }

    public List<ProductProperty> ProductProperties { get; }
}