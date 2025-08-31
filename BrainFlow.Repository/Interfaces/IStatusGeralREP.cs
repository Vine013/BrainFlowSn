using BrainFlow.Model;

namespace BrainFlow.Repository.Interfaces
{
    public interface IStatusGeralREP
    {
        /// <summary>
        /// Busca todos os status ativos do sistema.
        /// </summary>
        /// <returns>Uma lista de objetos StatusGeralMOD.</returns>
        Task<IEnumerable<StatusGeralMOD>> BuscarTodos();
    }
}
