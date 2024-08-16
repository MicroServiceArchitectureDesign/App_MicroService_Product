
namespace AppMicroServiceProduct.Domain.Brands;

public class Brand : AggregateRoot<long>
{
    private Brand()
    {
        
    }
    public Brand(IReadOnlyList<IDomainEvent> domainEvents) : base(domainEvents)
    {
    }

    public Brand(string title)
    {
        Apply(new BrandCreated(title));
    }

    public string Title { get; set; } = null!;

    public void UpdateBrand(string title)
    {
        Apply(new BrandUpdated(Id, title));
    }

    public void SetDeleteEvent()
    {
        Apply(new BrandDeleted(Id, Title, DateTime.Now));
    }

    private void On(BrandCreated brandCreated)
    {
        Title = brandCreated.Name;
    }
    private void On(BrandUpdated brandUpdated)
    {
        Id = brandUpdated.Id;
        Title = brandUpdated.Name;
    }
    private void On(BrandDeleted brandDeleted)
    {
        Id = brandDeleted.Id;
        Title = brandDeleted.Name;
    }
}
