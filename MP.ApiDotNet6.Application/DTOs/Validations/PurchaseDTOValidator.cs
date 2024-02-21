using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(p => p.CodErp)
                .NotEmpty().NotNull().WithMessage("Código ERP deve ser informado");

            RuleFor(p => p.Document)
                .NotEmpty().NotNull().WithMessage("Documento deve ser informado");
        }
    }
}
