using BrainFlow.Data;
using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using Dapper;

namespace BrainFlow.Repository
{
    public class StatusGeralREP : IStatusGeralREP
    {
        #region Conexoes
        private readonly AcessaDados _acessaDados;
        #endregion

        #region Construtor
        public StatusGeralREP(AcessaDados acessaDados)
        {
            _acessaDados = acessaDados;
        }
        #endregion

        #region Metodos

        #region BuscarTodos
        public async Task<IEnumerable<StatusGeralMOD>> BuscarTodos()
        {
            using (var con = _acessaDados.GetConnection())
            {
                var sql = @"SELECT CD_STATUS,
                                   NO_STATUS,
                                   TX_DESCRICAO,
                                   CD_USUARIO_ALTEROU,
                                   DT_ALTERACAO,
                                   SN_ATIVO
                              FROM STATUS_GERAL 
                             WHERE SN_ATIVO = 'S'";

                return await con.QueryAsync<StatusGeralMOD>(sql);
            }
        }
        #endregion

        #endregion
    }
}
