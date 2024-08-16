namespace AppMicroServiceProduct.Domain.ValueObjects;

public class OrderDetail : BaseValueObject<OrderDetail>
{
    public OrderDetail()
    {
        if (Quantity is <= 0)
            throw new InvalidDataException("Invalid Quantity");
        if (TotalToPay is <= 0)
            throw new InvalidDataException("Invalid TotalToPay");
        if (PayableAmountOfTheItem is <= 0)
            throw new InvalidDataException("Invalid PayableAmountOfTheItem");
        if (ProductPriceAtTheMoment is <= 0)
            throw new InvalidDataException("Invalid ProductPriceAtTheMoment");
        if (TotalDiscount is < 0)
            throw new InvalidDataException("Invalid TotalDiscount");
        if (DiscountedPercent is < 0)
            throw new InvalidDataException("Invalid DiscountedPercent");
    }
    public byte Quantity { get; set; }

    public long TotalToPay { get; set; }
    public long PayableAmountOfTheItem { get; set; }
    public long ProductPriceAtTheMoment { get; set; }
    public long TotalDiscount { get; set; }

    public float DiscountedPercent { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Quantity;
        yield return TotalToPay;
        yield return PayableAmountOfTheItem;
        yield return ProductPriceAtTheMoment;
        yield return TotalDiscount;
        yield return DiscountedPercent;
    }
}
