using AppMicroServiceProduct.Application.Features.Products.Common;

namespace AppMicroServiceProduct.Application.Features.Products.Commands.UpdateProductVariant;

public abstract class UpdateProductVariantCommand : ICommandRequest
{
    private UpdateProductVariantCommand()
    {
        
    }

    public long ProductId { get; set; }
    public IEnumerable<ProductVariantDto> ProductVariants { get; set; } = Enumerable.Empty<ProductVariantDto>();
}


public class UpdateProductVariantCommandHandler : CommandRequestHandler<UpdateProductVariantCommand>
{
    public override async Task<Result> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
    {
        // var existedVariants = await Repository.GetQuery(p => p.ProductId == request.ProductId)
        //     .Include(p=>p.ProductVariantOptions)
        //     .ToListAsync(cancellationToken);
        //
        // var requestVariantIds = request.ProductVariants.Select(p => p.Id).ToList();
        //
        // var maybeUpdatedItems = existedVariants
        //     .Where(p => requestVariantIds.Contains(p.Id))
        //     .ToList();
        //
        // foreach (var item in maybeUpdatedItems)
        // {
        //     var requestedItem = request.ProductVariants.Single(p => p.Id == item.Id);
        //     var requestedItemVariantOptions = requestedItem.ProductVariantOptions.Select(p=>p.VariantOptionId).ToList();
        //    
        //     var removedVariantOptions = item.ProductVariantOptions
        //         .Where(p => requestedItemVariantOptions.Contains(p.VariantOptionId) 
        //                     && p.ProductVariantId == item.Id)
        //         .ToList();
        //     
        //     var newVariantOptions = item.ProductVariantOptions
        //         .Where(p => requestedItemVariantOptions.Contains(p.VariantOptionId) 
        //                     && p.ProductVariantId == item.Id)
        //         .ToList();
        //     
        //     
        // }
        //
        //
        //
        //
        //
        // var removedItems = existedVariants
        //     .Where(p => !requestVariantIds.Contains(p.Id))
        //     .ToList();
        //
        // var newItems = request.ProductVariants
        //     .Where(p => !existedVariants.Select(q => q.Id).Contains(p.Id))
        //     .ToList();
        throw new NotImplementedException();
    }
}