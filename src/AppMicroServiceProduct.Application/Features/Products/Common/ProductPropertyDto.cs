namespace AppMicroServiceProduct.Application.Features.Products.Common;

public class ProductPropertyDto 
{
    public long ProductId { get; set; }
    public string Value { get; set; } = null!;
    public long DynamicPropertyId { get; set; }
}