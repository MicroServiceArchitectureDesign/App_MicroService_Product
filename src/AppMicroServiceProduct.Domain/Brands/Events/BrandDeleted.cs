namespace AppMicroServiceProduct.Domain.Brands.Events;

public class BrandDeleted : BaseBrandEvent
{
    public BrandDeleted(long id, string name, DateTime deletedOn)
    {
        DeletedOn = deletedOn;
        Id = id;
        Name = name;
    }

    public DateTime DeletedOn { get; set; }
    public long Id { get; set; }
}
