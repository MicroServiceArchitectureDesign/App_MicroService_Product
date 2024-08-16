using Mapster;

namespace AppMicroServiceProduct.Application.Features.Brands.Commands.CreateBrand;
public class CreateBrandCommand : ICommandRequest
{
    [Display(Name = "عنوان")]
    public string Title { get; set; } = null!;
}

public class CreateBrandCommandHandler : CommandRequestHandler<CreateBrandCommand>
{
    public override Task<Result> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var mappedEntity = request.Adapt<Brand>();
        //Repository.Insert(mappedEntity);
        //await UnitOfWork.CommitAndPublishDomainEventsAsync(cancellationToken);
        //await UnitOfWork.CommitAsync();
        return OkAsync();
    }
}