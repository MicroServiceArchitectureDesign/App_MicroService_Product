using AppMicroServiceProduct.Application.Features.Brands.Common;

namespace AppMicroServiceProduct.Application.Features.Brands.Queries.GetBrand;

public class GetBrandQuery : ICommandRequest<BrandQueryRQM>
{
    public GetBrandQuery(long id)
    {
        Id = id;
    }

    public long Id { get; }
}

public class GetBrandQueryHandler : CommandRequestHandler<GetBrandQuery, BrandQueryRQM>
{
    // private readonly IEventServiceStore _eventServiceStore;

    // public GetBrandQueryHandler(IEventServiceStore eventServiceStore)
    //{
        // _eventServiceStore = eventServiceStore;
    //}

    public override Task<Result<BrandQueryRQM>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        // var result = await _eventServiceStore.GetAsync($"{nameof(Brand)}-{request.Id}", cancellationToken);
        return OkAsync(new());
    }
}
