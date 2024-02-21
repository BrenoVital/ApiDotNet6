
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Validations
{
    public  class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Nome deve ser informado");

            RuleFor(p => p.CodErp)
                .NotEmpty().NotNull().WithMessage("Código ERP deve ser informado");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero");
        }   
    }
}
