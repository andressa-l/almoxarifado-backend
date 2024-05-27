using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ConexaoRepository 
    {
        public class PrimeiraConexao : IConexao {
            private readonly IConfiguration _configuration;

            public PrimeiraConexao(IConfiguration configuration) {
                _configuration = configuration;
            }

            public string GetConnectionString() {
                return _configuration.GetConnectionString("ConexaoResidencia");
            }
        }

        public class ReplicaConexao : IConexao 
        {
            private readonly IConfiguration _configuration;
            public ReplicaConexao(IConfiguration configuration) {
                _configuration = configuration;
            }

            public string GetConnectionString() {
                return _configuration.GetConnectionString("ConexaoReplicaSQL");
            }
        }
    }
}
