namespace AppMicroServiceProduct.Domain.Brands.Events;
public class BrandCreated : BaseBrandEvent
{
    public BrandCreated(string name)
    {
        Name = name;
    }
}
