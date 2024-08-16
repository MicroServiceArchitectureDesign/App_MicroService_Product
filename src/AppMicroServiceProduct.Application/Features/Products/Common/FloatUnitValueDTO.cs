using AppMicroServiceProduct.Domain.Products.Enums;

namespace AppMicroServiceProduct.Application.Features.Products.Common;

public abstract class FloatUnitValueDto
{
    public virtual required double Value { get; set; }
    public required Units Unit { get; set; }
}