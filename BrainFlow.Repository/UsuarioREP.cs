using BrainFlow.Data;
using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BrainFlow.Repository
{
    public class UsuarioREP : IUsuarioREP
    {
        #region Conexoes
        private readonly AcessaDados _acessaDados;
        #endregion

        #region Construtor
        public UsuarioREP(AcessaDados acessaDados)
        {
            _acessaDados = acessaDados;
        }
        #endregion

        #region Metodos

        #region BuscarPorCodigo
        /// <summary>
        /// Busca um usuário pelo código de usuário.
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        public async Task<UsuarioMOD> BuscarPorCodigo(int cdUsuario)
        {
            UsuarioMOD usuario = new UsuarioMOD();

            using (var con = _acessaDados.GetConnection())
            {
                try
                {
                    con.Open();
                    
                    var query = @"SELECT CD_USUARIO      AS CdUsuario,
                                         CD_TIPO_USUARIO AS CdTipoUsuario,
                                         NO_USUARIO      AS NoUsuario,
                                         TX_EMAIL        AS TxEmail,
                                         TX_TELEFONE     AS TxTelefone,
                                         DT_CADASTRO     AS DtCadastro,
                                         DT_ALTERACAO    AS DtAlteracao,
                                         SN_ATIVO        AS SnAtivo
                                    FROM USUARIO
                                   WHERE CD_USUARIO = @cdUsuario";

                    usuario = await con.QueryFirstOrDefaultAsync<UsuarioMOD>(query, new { cdUsuario });
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar usuário por código.", ex);
                }
            }
            return usuario;
        }
        #endregion

        #region BuscarPorEmail
        /// <summary>
        /// Busca um usuário pelo email.
        /// </summary>
        /// <param name="txEmail"></param>
        /// <returns></returns>
        public async Task<UsuarioMOD> BuscarPorEmail(string txEmail)
        {
            using (var con = _acessaDados.GetConnection())
            {
                try
                {
                    con.Open();

                    var query = @"SELECT CD_USUARIO      AS CdUsuario,
                                         CD_TIPO_USUARIO AS CdTipoUsuario,
                                         NO_USUARIO      AS NoUsuario,
                                         TX_EMAIL        AS TxEmail,
                                         TX_TELEFONE     AS TxTelefone,
                                         DT_CADASTRO     AS DtCadastro,
                                         DT_ALTERACAO    AS DtAlteracao,
                                         SN_ATIVO        AS SnAtivo
                                    FROM USUARIO
                                   WHERE TX_EMAIL = @txEmail";


                    var usuario = await con.QueryFirstOrDefaultAsync<UsuarioMOD>(query, new { txEmail });
                    return usuario;
                }
                 catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar usuário por e-mail.", ex);
                }
            }
        }
        #endregion

        #region Cadastrar
        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<int> Cadastrar(UsuarioMOD usuario)
        {
            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                SqlTransaction transacao = con.BeginTransaction();

                try
                {
                    string query = @"INSERT INTO USUARIO 
                                        (
                                        CD_TIPO_USUARIO, 
                                        NO_USUARIO, 
                                        TX_EMAIL, 
                                        TX_TELEFONE, 
                                        DT_CADASTRO, 
                                        SN_ATIVO
                                        )
                                  VALUES 
                                        (
                                        @CdTipoUsuario, 
                                        @NoUsuario, 
                                        @TxEmail, 
                                        @TxTelefone, 
                                        GETDATE(), 
                                        @SnAtivo
                                        );
                                SELECT SCOPE_IDENTITY();";

                    var cdUsuario = await con.QuerySingleAsync<int>(query, usuario,transacao);
                    transacao.Commit();
                    return cdUsuario;
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
        /// Edita um usuário existente no sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<bool> Editar(UsuarioMOD usuario)
        {
            bool editou = false;

            using (var con = _acessaDados.GetConnection())
            {
                con.Open();
                SqlTransaction transacao = con.BeginTransaction();

                try
                {
                    string quey = @"UPDATE USUARIO 
                                        SET 
                                            CD_TIPO_USUARIO = @CdTipoUsuario, 
                                            NO_USUARIO = @NoUsuario, 
                                            TX_EMAIL = @TxEmail, 
                                            TX_TELEFONE = @TxTelefone, 
                                            DT_ALTERACAO = @DtAlteracao, 
                                            SN_ATIVO = @SnAtivo
                                      WHERE CD_USUARIO = @CdUsuario;";

                    var parametros = await con.ExecuteScalarAsync(quey, usuario, transacao);

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
