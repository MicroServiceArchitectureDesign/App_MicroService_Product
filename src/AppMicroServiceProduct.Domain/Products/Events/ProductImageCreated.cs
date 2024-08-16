using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductImageCreated : IDomainEvent
{
    public ProductImageCreated(List<ProductImage>  productImages)
    {
        ProductImages = productImages;
    }

    public List<ProductImage> ProductImages { get; }
}