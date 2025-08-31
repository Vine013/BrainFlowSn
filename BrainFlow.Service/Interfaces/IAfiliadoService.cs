using BrainFlow.Model;

namespace BrainFlow.Service.Interfaces
{
    public interface IAfiliadoService
    {
        /// <summary>
        /// Busca uma lista de afiliados que estão aguardando aprovação.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AfiliadoMOD>> BuscarAfiliadosPendentes();

        /// <summary>
        /// Aprova o cadastro de um afiliado.
        /// </summary>
        /// <param name="cdAfiliado"></param>
        /// <returns></returns>
        Task<bool> AprovarAfiliado(int cdAfiliado);

        /// <summary>
        /// Cadastra um novo afiliado no sistema.
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task<int> CadastrarAfiliado(AfiliadoMOD afiliado);
    }
}
