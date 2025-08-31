using BrainFlow.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainFlow.Repository.Interfaces
{
    public interface IAfiliadoREP
    {
        /// <summary>
        /// Busca um afiliado pelo código do usuário.
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        Task<AfiliadoMOD> BuscarPorCodigoUsuario(int cdUsuario);

        /// <summary>
        /// Busca uma lista de afiliados por status.
        /// </summary>
        /// <param name="cdStatus"></param>
        /// <returns></returns>
        Task<IEnumerable<AfiliadoMOD>> BuscarPorStatus(int cdStatus);

        /// <summary>
        /// Cadastra um novo afiliado no sistema.
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task<int> Cadastrar(AfiliadoMOD afiliado);

        /// <summary>
        /// Edita um afiliado existente no sistema.
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task<bool> Editar(AfiliadoMOD afiliado);
    }
}
