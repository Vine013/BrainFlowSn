using BrainFlow.Model;

namespace BrainFlow.Repository.Interfaces
{
    public interface IUsuarioLoginREP
    {
        /// <summary>
        /// Busca as credenciais de login de um usuário por código de usuário.
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        Task<UsuarioLoginMOD> BuscarPorCodigoUsuario(int cdUsuario);

        /// <summary>
        /// Cadastra as credenciais de login de um novo usuário.
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        Task<int> Cadastrar(UsuarioLoginMOD usuarioLogin);

        /// <summary>
        /// Edita as credenciais de login de um usuário existente.
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        Task<bool> Editar(UsuarioLoginMOD usuarioLogin);
    }
}
