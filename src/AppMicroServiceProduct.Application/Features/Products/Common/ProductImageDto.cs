namespace AppMicroServiceProduct.Application.Features.Products.Common;

public class ProductImageDto : BaseLongId
{
    public long ProductId { get; set; }
    public required string Name { get; set; }
    public required string Extension { get; set; }
}