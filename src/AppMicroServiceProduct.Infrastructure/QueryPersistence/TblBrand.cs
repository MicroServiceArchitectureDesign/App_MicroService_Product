namespace AppMicroServiceProduct.Infrastructure.QueryPersistence;

public partial class TblBrand
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public Guid BusinessId { get; set; }
}
