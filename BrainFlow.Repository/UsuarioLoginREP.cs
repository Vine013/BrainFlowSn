using BrainFlow.Data;
using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BrainFlow.Repository
{
    public class UsuarioLoginREP : IUsuarioLoginREP
    {
        #region Conexoes
        private readonly AcessaDados _acessaDados;
        #endregion

        #region Construtor
        public UsuarioLoginREP(AcessaDados acessaDados)
        {
            _acessaDados = acessaDados;
        }
        #endregion

        #region Metodos

        #region BuscarPorCodigoUsuario
        /// <summary>
        /// Busca as credenciais de login de um usuário por código de usuário.
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        public async Task<UsuarioLoginMOD> BuscarPorCodigoUsuario(int cdUsuario)
        {
            UsuarioLoginMOD usuarioLogin = new UsuarioLoginMOD();

            using (var con = _acessaDados.GetConnection())
            {
                try
                {
                    con.Open();

                    var query = @"SELECT UL.CD_LOGIN      AS CdLogin,
                                    	 UL.CD_USUARIO    AS CdUsuario,
                                    	 UL.DT_ALTERACAO  AS DtAlteracao,
                                    	 UL.TX_SENHA_HASH AS TxSenhaHash,
                                    	 UL.TX_TOKEN      AS TxToken
                                    FROM USUARIO_LOGIN UL
                                   WHERE UL.CD_USUARIO = @cdUsuario";

                    usuarioLogin = await con.QueryFirstOrDefaultAsync<UsuarioLoginMOD>(query, new { cdUsuario });
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar usuário por código.", ex);
                }
            }
            return usuarioLogin;
        }
        #endregion

        #region Cadastrar
        /// <summary>
        /// Cadastra as credenciais de login de um novo usuário.
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        public async Task<int> Cadastrar(UsuarioLoginMOD usuarioLogin)
        {

            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                SqlTransaction transacao = con.BeginTransaction();

                try
                {
                    string query = @"INSERT INTO USUARIO_LOGIN 
                                            (
                                             CD_USUARIO, 
                                             TX_SENHA_HASH,  
                                             DT_ALTERACAO
                                            )
                                      VALUES 
                                            (
                                             @CdUsuario, 
                                             @TxSenhaHash, 
                                             @DtAlteracao
                                            );
                                      SELECT SCOPE_IDENTITY();";

                    var cdLogin = await con.ExecuteScalarAsync<int>(query, usuarioLogin, transacao);
                    transacao.Commit();
                    return cdLogin;
                }
                catch (SqlException ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao cadastrar usuário.", ex);
                }
            }
        }
        #endregion

        #region Editar
        /// <summary>
        /// Edita as credenciais de login de um usuário existente.
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        public async Task<bool> Editar(UsuarioLoginMOD usuarioLogin)
        {
            bool editou = false;

            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                SqlTransaction transacao = con.BeginTransaction();
                try
                {
                    string query = @"UPDATE USUARIO_LOGIN SET 
                                            TX_SENHA_HASH = @TxSenhaHash, 
                                            DT_ALTERACAO = @DtAlteracao
                                      WHERE CD_USUARIO = @CdUsuario";

                    var parametros = await con.ExecuteScalarAsync(query, usuarioLogin, transacao);

                    transacao.Commit();
                    editou = true;
                }
                catch (SqlException ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao editar usuário.", ex);
                }
            }
            return editou;
        }
        #endregion

        #endregion
    }
}
