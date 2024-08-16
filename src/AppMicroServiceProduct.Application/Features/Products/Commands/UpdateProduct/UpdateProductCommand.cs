using AppMicroServiceProduct.Application.Features.Products.Common;
using AppMicroServiceProduct.Domain.Products.Entities;
using Mapster;

namespace AppMicroServiceProduct.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : BaseCreateUpdateProductCommand
{
}

public class UpdateProductCommandHandler : CommandRequestHandler<UpdateProductCommand>
{
    public override async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Product? originalEntity = await Repository.GetGraphAsync(request.Id);
        Product productEntity = request.Adapt<Product>();
        // originalEntity.ThrowIfNull("Request item not found..!");
        // Repository.PartialUpdateTest(originalEntity!,productEntity, p=>p.Images);
        
        return await OkAsync();
    }
}