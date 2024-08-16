using AppMicroServiceProduct.Application.Features.Products.Common;
using AppMicroServiceProduct.Domain.Products.Entities;
using Mapster;

namespace AppMicroServiceProduct.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : BaseCreateAndUpdateCommandDto, ICommandRequest
{
}

public class CreateProductCommandHandler : CommandRequestHandler<CreateProductCommand>
{
    public override async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product productEntity = request.Adapt<Product>();
        //await Repository.InsertAsync(productEntity);
        //await UnitOfWork.CommitAsync();
        return await OkAsync();
    }
}