
namespace AppMicroServiceProduct.Domain.Brands.Events;

public class BaseBrandEvent : IDomainEvent
{
    public string Name { get; set; } = null!;
}
