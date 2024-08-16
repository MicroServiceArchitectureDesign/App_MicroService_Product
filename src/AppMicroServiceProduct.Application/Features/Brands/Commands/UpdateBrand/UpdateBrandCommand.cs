namespace AppMicroServiceProduct.Application.Features.Brands.Commands.UpdateBrand;
public class UpdateBrandCommand : ICommandRequest
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
}

public class UpdateBrandCommandHandler : CommandRequestHandler<UpdateBrandCommand>
{
    public override Task<Result> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        // Brand? brand = await Repository.GetAsync(request.Id);
        // if (brand is null)
        // {
        //     throw new NullException("Brand not found");
        // }
        //
        // brand.UpdateBrand(request.Title);
        // await UnitOfWork.CommitAndPublishDomainEventsAsync(cancellationToken);
        return OkAsync();
    }
}