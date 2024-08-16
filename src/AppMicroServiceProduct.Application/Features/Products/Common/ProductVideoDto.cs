namespace AppMicroServiceProduct.Application.Features.Products.Common;

public class ProductVideoDto : BaseLongId
{
    public long ProductId { get; set; }
    public required string Name { get; set; }
    public required string Extension { get; set; }
}