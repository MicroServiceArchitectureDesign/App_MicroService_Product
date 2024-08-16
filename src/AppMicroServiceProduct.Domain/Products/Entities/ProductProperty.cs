using AppMicroServiceProduct.Domain.DynamicProperties;

namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductProperty : LongEntity
{
    public string Value { get; set; } = null!;

    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public long DynamicPropertyId { get; set; }
    public DynamicProperty DynamicProperty { get; set; } = null!;
}
