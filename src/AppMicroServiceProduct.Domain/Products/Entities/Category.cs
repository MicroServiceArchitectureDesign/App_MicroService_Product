namespace AppMicroServiceProduct.Domain.Products.Entities;

public class Category : AggregateRoot<long>
{
    public Title Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
}
