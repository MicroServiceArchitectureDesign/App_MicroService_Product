namespace AppMicroServiceProduct.Domain.Products.Entities;

public class SubCategory : LongEntity
{
    public Title Name { get; set; } = null!;

    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ICollection<ProductSubCategory> ProductSubCategories { get; set; } = new HashSet<ProductSubCategory>();
}