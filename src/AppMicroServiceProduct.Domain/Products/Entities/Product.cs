using AppMicroServiceProduct.Domain.Products.Enums;
using AppMicroServiceProduct.Domain.Products.Events;

namespace AppMicroServiceProduct.Domain.Products.Entities;

public class Product : AggregateRoot<long>
{
    #region Fields

    public ProductName Name { get; set; } = null!;
    public Description Description { get; set; } = null!;
    public ProductQuantity Quantity { get; set; } = null!;
    public Price Price { get; set; } = null!;
    public double DiscountedPercent { get; set; }
    public ProductAvailabilityStatus AvailabilityStatus { get; set; } = ProductAvailabilityStatus.Available;

    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ProductWeightAndShipping? ProductWeightAndShipping { get; set; }

    public ICollection<ProductSubCategory> ProductSubCategories { get; set; } = new HashSet<ProductSubCategory>();
    public ICollection<ProductVariant> Variants { get; set; } = new HashSet<ProductVariant>();
    public ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();
    public ICollection<ProductVideo> Videos { get; set; } = new HashSet<ProductVideo>();
    public ICollection<ProductProperty> Properties { get; set; } = new HashSet<ProductProperty>();

    #endregion

    #region Constructors

    public Product()
    {
    }

    public Product(IReadOnlyList<IDomainEvent> domainEvents) : base(domainEvents)
    {
    }

    public Product(
        long id,
        ProductName name,
        Description description,
        ProductQuantity quantity,
        Price price,
        double discountedPercent,
        ProductAvailabilityStatus availabilityStatus,
        long categoryId,
        ProductWeightAndShipping? productWeightAndShipping = null)
    {
        Id = id;
        Apply(new ProductCreated(name.Value,
            description.Value,
            quantity.Value,
            price.Value,
            discountedPercent,
            availabilityStatus.Value,
            categoryId,
            productWeightAndShipping));
    }

    public Product(long id,
        ProductName name,
        Description description,
        ProductQuantity quantity,
        Price price,
        double discountedPercent,
        byte availabilityStatus,
        long categoryId,
        ProductWeightAndShipping? productWeightAndShipping = null)
    {
        Apply(new ProductUpdated(id,
            name.Value,
            description.Value,
            quantity.Value,
            price.Value,
            discountedPercent,
            availabilityStatus,
            categoryId,
            productWeightAndShipping));
    }

    #endregion

    #region Methods

    public Product AddSubCategories(List<ProductSubCategory> subcategories)
    {
        foreach (ProductSubCategory item in subcategories)
        {
            ProductSubCategories.Add(item);
        }

        AddEvent(new ProductSubCategoryCreated(subcategories));
        return this;
    }

    public Product AddImages(List<ProductImage> productImages)
    {
        foreach (ProductImage item in productImages)
        {
            Images.Add(item);
        }

        AddEvent(new ProductImageCreated(productImages));
        return this;
    }

    public Product AddVariants(List<ProductVariant> productVariants)
    {
        foreach (ProductVariant item in productVariants)
        {
            Variants.Add(item);
        }

        AddEvent(new ProductVariantCreated(productVariants));
        return this;
    }

    public Product AddVideos(List<ProductVideo> productVideos)
    {
        foreach (ProductVideo item in productVideos)
        {
            Videos.Add(item);
        }

        AddEvent(new ProductVideoCreated(productVideos));
        return this;
    }

    public Product AddProperties(List<ProductProperty> productProperties)
    {
        foreach (ProductProperty item in productProperties)
        {
            Properties.Add(item);
        }

        AddEvent(new ProductPropertyCreated(productProperties));
        return this;
    }


    private protected void On(ProductCreated brandCreated)
    {
        Name = brandCreated.Name;
        Description = brandCreated.Description;
        Quantity = brandCreated.Quantity;
        Price = brandCreated.Price;
        DiscountedPercent = brandCreated.DiscountedPercent;
        AvailabilityStatus = ProductAvailabilityStatus.FromValue(brandCreated.AvailabilityStatus);
        CategoryId = brandCreated.CategoryId;
        ProductWeightAndShipping = brandCreated.ProductWeightAndShipping;
    }

    private protected void On(ProductUpdated productUpdated)
    {
        Id = productUpdated.Id;
        Name = productUpdated.Name;
        Description = productUpdated.Description;
        Quantity = productUpdated.Quantity;
        Price = productUpdated.Price;
        DiscountedPercent = productUpdated.DiscountedPercent;
        // AvailabilityStatus = productUpdated.AvailabilityStatus;
        CategoryId = productUpdated.CategoryId;
        ProductWeightAndShipping = productUpdated.ProductWeightAndShipping;
    }

    #endregion
}