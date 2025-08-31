using BrainFlow.Repository.Interfaces;
using BrainFlow.Service.Interfaces;
using BCrypt.Net;
using BrainFlow.Model;

namespace BrainFlow.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        #region Conexoes
        private readonly IUsuarioREP _usuarioREP;
        private readonly IUsuarioLoginREP _usuarioLoginREP;
        #endregion

        #region Construtor
        public AutenticacaoService(IUsuarioREP usuarioREP, IUsuarioLoginREP usuarioLoginREP)
        {
            _usuarioREP = usuarioREP;
            _usuarioLoginREP = usuarioLoginREP;
        }
        #endregion

        #region Metodos

        #region Login
        /// <summary>
        /// Realiza o login de um usuário na plataforma.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<UsuarioMOD> Login(Login login)
        {
            var usuario = await _usuarioREP.BuscarPorEmail(login.Username);
            if (usuario == null)
            {
                return null;
            }

            var usuarioLogin = await _usuarioLoginREP.BuscarPorCodigoUsuario(usuario.CdUsuario);
            if (usuarioLogin == null)
            {
                return null;
            }

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(login.Password, usuarioLogin.TxSenhaHash);

            if (senhaCorreta)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region CadastrarUsuarioComum
        /// <summary>
        /// Realiza o cadastro de um novo usuário comum.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<int> CadastrarUsuarioComum(UsuarioMOD usuario, string senha)
        {
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            usuario.SnAtivo = "S";
            usuario.DtCadastro = DateTime.Now;
            usuario.CdTipoUsuario = 3;
            int cdUsuario = await _usuarioREP.Cadastrar(usuario);

            if (cdUsuario != 0)
            {
                var usuarioLogin = new UsuarioLoginMOD
                {
                    CdUsuario = cdUsuario,
                    TxSenhaHash = senhaHash,
                    DtAlteracao = DateTime.Now
                };
                await _usuarioLoginREP.Cadastrar(usuarioLogin);

                return cdUsuario;
            }

            return 0; 
        }
        #endregion

        #endregion
    }
}
