using BrainFlow.Data;
using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using Dapper;

namespace BrainFlow.Repository
{
    public class UsuarioTipoREP : IUsuarioTipoREP
    {
        #region Conexoes
        private readonly AcessaDados _acessaDados;
        #endregion

        #region Construtor
        public UsuarioTipoREP(AcessaDados acessaDados)
        {
            _acessaDados = acessaDados;
        }
        #endregion

        #region Metodos

        #region BuscarTodos
        public async Task<IEnumerable<UsuarioTipoMOD>> BuscarTodos()
        {
            using (var con = _acessaDados.GetConnection())
            {
                var sql = @"SELECT CD_TIPO_USUARIO,
                                   NO_TIPO_USUARIO,
                                   SN_ATIVO,
                                   CD_USUARIO_ALTEROU,
                                   DT_ALTERACAO
                              FROM USUARIO_TIPO 
                             WHERE SN_ATIVO = 'S'";

                return await con.QueryAsync<UsuarioTipoMOD>(sql);
            }
        }

        #endregion

        #region BuscarPorCodigo
        public async Task<UsuarioTipoMOD> BuscarPorCodigo(int cdTipoUsuario)
        {
            using (var con = _acessaDados.GetConnection())
            {
                var sql = @"SELECT CD_TIPO_USUARIO,
                                   NO_TIPO_USUARIO,
                                   SN_ATIVO,
                                   CD_USUARIO_ALTEROU,
                                   DT_ALTERACAO 
                              FROM USUARIO_TIPO 
                             WHERE CD_TIPO_USUARIO = @cdTipoUsuario";

                return await con.QueryFirstOrDefaultAsync<UsuarioTipoMOD>(sql, new { cdTipoUsuario });
            }
        }
        #endregion

        #endregion
    }
}
