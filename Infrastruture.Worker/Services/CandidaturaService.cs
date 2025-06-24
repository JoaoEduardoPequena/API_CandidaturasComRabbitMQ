using DomainReport.Worker.DTO;
using Infrastruture.Worker.Interfaces;
using Infrastruture.Worker.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using Microsoft.Data.SqlClient;
namespace Infrastruture.Worker.Services
{
    public class CandidaturaService : ICandidaturaService
    {
        private readonly ConnectionStringSetting _connection;
        private readonly ILogger<CandidaturaService> _logger;
        public CandidaturaService(IOptions<ConnectionStringSetting> connection, ILogger<CandidaturaService> logger)
        {
            _connection = connection.Value;
            _logger = logger;
        }
        public async Task<CandidaturaReportDTO> ObterCandidaturaReport(Guid idCandidatura)
        {
            try
            {
                var query = @"SELECT
                cand.IdCandidatura,
                cand.Nome,
                cand.Email,
                cand.Telefone,
                cand.NumeroBI,
                cand.NumeroCandidatura,
                cand.DataNascimento,
                cand.DataCriacao,
                e.EstadoCandidatura,
                c.NomeCategoria,
                p.NomeProvincia
              FROM 
                Candidatura cand WITH(NOLOCK)
                INNER JOIN 
                   Categoria cand WITH(NOLOCK) ON c.IdCategoria = cand.IdCategoria
                INNER JOIN 
                    EstadoCandidatura e WITH(NOLOCK) ON e.IdEstado = c.IdEstadoCandidatura
                INNER JOIN 
                    Provincia p WITH(NOLOCK) ON p.IdProvincia = c.IdProvincia
                WHERE c.IdCandidatura=@IdCandidatura";
                using var connection = new SqlConnection(_connection.ConnectionString);
                var parameters = new { IdCandidatura = idCandidatura };
                await connection.OpenAsync();
                var result = await connection.QueryFirstOrDefaultAsync<CandidaturaReportDTO>(query, parameters, commandTimeout: 120);
                if (result is not null) return result;
                return new CandidaturaReportDTO();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Erro ao obter candidatura com IdCandidatura {idCandidatura}. Detalhe do erro: {ex.Message}";
                _logger.LogError(errorMessage);
                return new CandidaturaReportDTO();
            }
        }
    }
}
