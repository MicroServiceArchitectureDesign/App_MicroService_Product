namespace AppMicroServiceProduct.Domain.Brands.Events;

public class BrandUpdated : BaseBrandEvent
{
    public BrandUpdated(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public long Id { get; set; }
}
