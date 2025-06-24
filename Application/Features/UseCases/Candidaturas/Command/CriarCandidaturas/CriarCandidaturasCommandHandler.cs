using Application.DTO.Candidaturas;
using Application.Interfaces;
using Application.Setting;
using Domain.Entites;
using Domain.Interfaces;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Features.UseCases.Candidaturas.Command.CriarCandidaturas
{
    public class CriarCandidaturasCommandHandler : IRequestHandler<CriarCandidaturasCommand, bool>
    {
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IValidator<CriarCandidaturasCommand> _validator;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly RabbitMqSetting _rabbitMqSetting;
        public CriarCandidaturasCommandHandler(ICandidaturaRepository candidaturaRepository, IValidator<CriarCandidaturasCommand> validator, IRabbitMQService  rabbitMQService, IOptions<RabbitMqSetting> rabbitMqSetting)
        {
            _candidaturaRepository = candidaturaRepository;
            _validator = validator;
            _rabbitMQService = rabbitMQService;
            _rabbitMqSetting = rabbitMqSetting.Value;
        }

        public async Task<bool> Handle(CriarCandidaturasCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid) return false;
            var dto=request.Adapt<Candidatura>();
            dto.IdCandidatura=Guid.NewGuid();
            dto.DataCriacao=DateTime.Now;
            dto.NumeroCandidatura= $"{DateTime.Now:yyyyMMddHHmmss}-{dto.IdCandidatura:N}".ToUpperInvariant();
            var result=await _candidaturaRepository.CriarCandidatura(dto);
            if(!result) return false;
            var candMessage = dto.Adapt<CandidaturaMessageDTO>();
            result = await _rabbitMQService.PublishAsync(candMessage, _rabbitMqSetting.QueueCandidaturas);
            return result;
        }
    }
}
