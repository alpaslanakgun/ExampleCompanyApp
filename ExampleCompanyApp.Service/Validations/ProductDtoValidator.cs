using ExampleCompanyApp.Core.DTOs;
using FluentValidation;

namespace ExampleCompanyApp.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(X => X.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");
            RuleFor(X => X.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");

        }
    }
}
