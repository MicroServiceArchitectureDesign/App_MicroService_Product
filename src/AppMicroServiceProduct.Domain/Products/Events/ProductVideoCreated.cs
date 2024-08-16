using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductVideoCreated : IDomainEvent
{
    public ProductVideoCreated(List<ProductVideo>  productVideos)
    {
        ProductVideos = productVideos;
    }

    public List<ProductVideo> ProductVideos { get; }
}