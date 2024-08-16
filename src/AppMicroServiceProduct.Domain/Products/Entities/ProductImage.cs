namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductImage : LongEntity
{
    public required string Name { get; set; }
    public required string Extension { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
