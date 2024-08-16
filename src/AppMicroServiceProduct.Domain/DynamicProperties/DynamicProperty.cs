using AppMicroServiceProduct.Domain.Products.Entities;

namespace AppMicroServiceProduct.Domain.DynamicProperties;
public class DynamicProperty : AggregateRoot<long>
{
    public DynamicProperty(string key)
    {
        Key = key;
    }

    public string Key { get; private set; } = null!;

    public ICollection<ProductProperty> ProductProperties { get; private set; } = new HashSet<ProductProperty>();
}
