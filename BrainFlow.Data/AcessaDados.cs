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
        public SqlConnection GetConnection()
        {
            string BrainFlowConnection = _configuration.GetConnectionString("BrainFlowConnection");

            return new SqlConnection(BrainFlowConnection);
        }
        #endregion
    }
}
