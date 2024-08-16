namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductSubCategory : LongEntity
{
    public long SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; } = null!;

    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;

}