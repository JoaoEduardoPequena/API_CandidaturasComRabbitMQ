using FluentValidation;

namespace Application.Features.UseCases.Candidaturas.Command.CriarCandidaturas
{
    public class CriarCandidaturasCommandValidator : AbstractValidator<CriarCandidaturasCommand>
    {
        public CriarCandidaturasCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cliente não pode exceder 100 caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email do cliente é obrigatório.")
                .EmailAddress().WithMessage("O email do cliente deve ser um endereço de email válido.");
        }
    }
}
