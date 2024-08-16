namespace AppMicroServiceProduct.Domain.Products.Entities;

public class ProductWeightAndShipping 
{
    public required FloatUnitValue Weight { get; set; }
    public required FloatUnitValue Height { get; set; }
    public required FloatUnitValue Width { get; set; }
    public required FloatUnitValue Length { get; set; }
    public byte ShipingInsurance { get; set; }
    public byte ShippingService { get; set; }

}
