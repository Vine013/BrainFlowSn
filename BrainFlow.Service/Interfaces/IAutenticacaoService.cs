using BrainFlow.Model;

namespace BrainFlow.Service.Interfaces
{
    public interface IAutenticacaoService
    {
        /// <summary>
        /// Realiza o login de um usuário na plataforma.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Retorna o usuário se o login for bem-sucedido, caso contrário null.</returns>
        Task<UsuarioMOD> Login(Login login);

        /// <summary>
        /// Realiza o cadastro de um novo usuário comum.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna o código do novo usuário.</returns>
        Task<int> CadastrarUsuario(UsuarioMOD usuario, string senha);
    }
}
