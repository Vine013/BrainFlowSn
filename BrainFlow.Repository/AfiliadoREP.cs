using BrainFlow.Data;
using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BrainFlow.Repository
{
    public class AfiliadoREP : IAfiliadoREP
    {
        #region Conexoes
        private readonly AcessaDados _acessaDados;
        #endregion

        #region Construtor
        public AfiliadoREP(AcessaDados acessaDados)
        {
            _acessaDados = acessaDados;
        }
        #endregion

        #region Metodos

        #region BuscarPorCodigoUsuario
        public async Task<AfiliadoMOD> BuscarPorCodigoUsuario(int cdUsuario)
        {
            using (var con = _acessaDados.GetConnection())
            {
                try
                {
                    con.Open();
                    var query = @"SELECT   A.CD_AFILIADO       AS CdAfiliado,
                                    	   A.CD_STATUS         AS CdStatus,
                                    	   A.CD_USUARIO        AS CdUsuario,
                                    	   A.DT_APROVACAO      AS DtAprovacao,
                                    	   A.DT_SOLICITACAO    AS DtSolicitacao,
                                    	   A.NO_RAZAO_SOCIAL   AS NoRazaoSocial,
                                    	   A.NR_CPF_CNPJ       AS NrCpfCnpj
                                      FROM AFILIADO 
                                     WHERE CD_USUARIO = @cdUsuario";
                    return await con.QueryFirstOrDefaultAsync<AfiliadoMOD>(query, new { cdUsuario });
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar afiliado por código de usuário.", ex);
                }
            }
        }
        #endregion

        #region BuscarPorStatus
        public async Task<IEnumerable<AfiliadoMOD>> BuscarPorStatus(int cdStatus)
        {
            using (var con = _acessaDados.GetConnection())
            {
                try
                {
                    con.Open();
                    var query = @"SELECT   A.CD_AFILIADO       AS CdAfiliado,
                                    	   A.CD_STATUS         AS CdStatus,
                                    	   A.CD_USUARIO        AS CdUsuario,
                                    	   A.DT_APROVACAO      AS DtAprovacao,
                                    	   A.DT_SOLICITACAO    AS DtSolicitacao,
                                    	   A.NO_RAZAO_SOCIAL   AS NoRazaoSocial,
                                    	   A.NR_CPF_CNPJ       AS NrCpfCnpj
                                      FROM AFILIADO A
                                     WHERE CD_STATUS = @cdStatus";

                    return await con.QueryAsync<AfiliadoMOD>(query, new { cdStatus });
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar afiliados por status.", ex);
                }
            }
        }
        #endregion

        #region Cadastrar
        public async Task<int> Cadastrar(AfiliadoMOD afiliado)
        {
            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                var transacao = con.BeginTransaction();
                try
                {
                    var query = @"INSERT INTO AFILIADO 
                                              (CD_USUARIO, 
                                               NR_CPF_CNPJ, 
                                               NO_RAZAO_SOCIAL, 
                                               DT_SOLICITACAO, 
                                               DT_APROVACAO, 
                                               CD_STATUS)
                                         VALUES 
                                               (@CdUsuario, 
                                               @NrCpfCnpj, 
                                               @NoRazaoSocial, 
                                               GETDATE(), 
                                               @DtAprovacao, 
                                               @CdStatus);
                                  SELECT SCOPE_IDENTITY();";

                    var cdAfiliado = await con.QuerySingleAsync<int>(query, afiliado, transacao);
                    transacao.Commit();
                    return cdAfiliado;
                }
                catch (SqlException ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao cadastrar afiliado.", ex);
                }
            }
        }
        #endregion

        #region Editar
        public async Task<bool> Editar(AfiliadoMOD afiliado)
        {
            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                var transacao = con.BeginTransaction();
                try
                {
                    var query = @"UPDATE AFILIADO SET 
                                         NR_CPF_CNPJ = @NrCpfCnpj, 
                                         NO_RAZAO_SOCIAL = @NoRazaoSocial, 
                                         CD_STATUS = @CdStatus, 
                                         DT_APROVACAO = @DtAprovacao
                                   WHERE CD_AFILIADO = @CdAfiliado;";

                    var linhasAfetadas = await con.ExecuteAsync(query, afiliado, transacao);
                    transacao.Commit();
                    return linhasAfetadas > 0;
                }
                catch (SqlException ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao editar afiliado.", ex);
                }
            }
        }
        #endregion

        #endregion
    }
}
