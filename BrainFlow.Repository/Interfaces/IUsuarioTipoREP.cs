using BrainFlow.Model;

namespace BrainFlow.Repository.Interfaces
{
    public interface IUsuarioTipoREP
    {
        /// <summary>
        /// Busca todos os tipos de usuário ativos.
        /// </summary>
        /// <returns>Uma lista de objetos UsuarioTipoMOD.</returns>
        Task<IEnumerable<UsuarioTipoMOD>> BuscarTodos();

        /// <summary>
        /// Busca um tipo de usuário pelo código.
        /// </summary>
        /// <param name="cdTipoUsuario"></param>
        /// <returns>Um objeto UsuarioTipoMOD.</returns>
        Task<UsuarioTipoMOD> BuscarPorCodigo(int cdTipoUsuario);
    }
}
