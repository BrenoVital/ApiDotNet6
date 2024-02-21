
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTO.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Nome deve ser informado");

            RuleFor(p => p.Document)
                .NotEmpty().NotNull().WithMessage("Documento deve ser informado");

            RuleFor(p => p.Phone)
                .NotEmpty().NotNull().WithMessage("Número de telefone deve ser informado");
        }
    }
}
