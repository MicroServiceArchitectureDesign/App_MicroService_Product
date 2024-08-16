namespace AppMicroServiceProduct.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : BaseValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .NotNull()
            .MustAsync(ShouldBeUniqueTitle);
    }

    private Task<bool> ShouldBeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
