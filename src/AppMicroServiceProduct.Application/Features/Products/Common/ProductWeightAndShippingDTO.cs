namespace AppMicroServiceProduct.Application.Features.Products.Common;

public  class ProductWeightAndShippingDTO
{
    public required FloatUnitValueDto Weight { get; set; }
    public required FloatUnitValueDto Height { get; set; }
    public required FloatUnitValueDto Width { get; set; }
    public required FloatUnitValueDto Length { get; set; }
    public byte ShipingInsurance { get; set; }
    public byte ShippingService { get; set; }
}