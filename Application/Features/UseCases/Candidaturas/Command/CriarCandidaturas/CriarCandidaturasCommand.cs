using MediatR;

namespace Application.Features.UseCases.Candidaturas.Command.CriarCandidaturas
{
    public record CriarCandidaturasCommand
    (
      string Nome,
      string Email,
      string NumeroBI,
      string Telefone,
      DateTime DataNascimento,
      int IdCategoria,
      int IdProvincia
    ) :IRequest<bool>;
}
