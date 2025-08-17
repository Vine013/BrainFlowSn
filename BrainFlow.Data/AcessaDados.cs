using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BrainFlow.Data
{
    public sealed class AcessaDados
    {
        #region Repositorios
        private readonly IConfiguration _configuration;
        #endregion

        #region Construtor
        public AcessaDados(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Conexão
        /// <summary>
        /// Recupera a string de conexão do banco de dados configurada no appsettings.json
        /// e efetua a conexão com o banco de dados SQL Server.
        /// <returns>Retorna a string de conexão do banco de dados.</returns>
        public SqlConnection GetConnection()
        {
            string BrainFlowConnection = _configuration.GetConnectionString("BrainFlowConnection");

            return new SqlConnection(BrainFlowConnection);
        }
        #endregion
    }
}
