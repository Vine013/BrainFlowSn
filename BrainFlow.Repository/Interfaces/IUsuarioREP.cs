using BrainFlow.Model;

namespace BrainFlow.Repository.Interfaces
{
    public interface IUsuarioREP
    {
        /// <summary>
        /// Busca um usuário pelo código do usuário.
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        Task<UsuarioMOD> BuscarPorCodigo(int cdUsuario);

        /// <summary>
        /// Busca um usuário pelo email do usuário.
        /// </summary>
        /// <param name="txEmail"></param>
        /// <returns></returns> 
        Task<UsuarioMOD> BuscarPorEmail(string txEmail);

        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns> 
        Task<int> Cadastrar(UsuarioMOD usuario);

        /// <summary>
        /// Edita um usuário existente no sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns> 
        Task<bool> Editar(UsuarioMOD usuario);
    }
}
