using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.Products.Events;

public class ProductSubCategoryCreated : IDomainEvent
{
    public ProductSubCategoryCreated(List<ProductSubCategory> subcategories)
    {
        Subcategories = subcategories;
    }

    public List<ProductSubCategory> Subcategories { get; }
}