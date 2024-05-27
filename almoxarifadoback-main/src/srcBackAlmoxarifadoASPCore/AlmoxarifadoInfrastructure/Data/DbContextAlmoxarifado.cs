using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using static AlmoxarifadoInfrastructure.Data.Repositories.ConexaoRepository;

namespace AlmoxarifadoInfrastructure.Data
{
    public class ConexaoService
    {
        private readonly PrimeiraConexao _primeiraConexao;
        private readonly ReplicaConexao _replicaConexao;
        private readonly ILogger<ConexaoService> _logger;

        public ConexaoService(PrimeiraConexao primeiraConexao, ReplicaConexao replicaConexao, ILogger<ConexaoService> logger)
        {
            _primeiraConexao = primeiraConexao;
            _replicaConexao = replicaConexao;
            _logger = logger;
        }

        public string GetConnectionString()
        {
            if (VerificarConexao(_primeiraConexao.GetConnectionString())) {
                return _primeiraConexao.GetConnectionString();
            }
            else {
                _logger.LogWarning("Conexão primária indisponível. Tentando conexão de réplica.");
                return _replicaConexao.GetConnectionString();
            }
        }

        private bool VerificarConexao(string connectionString) {
            // Verifica se a conexão com o banco de dados está disponível
            try {
                using (var conexao = new SqlConnection(connectionString)) {
                    conexao.Open();
                    return true;
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Erro ao tentar conectar usando a string de conexão: {ConnectionString}", connectionString);
                return false;
            }
        }
    }
}
