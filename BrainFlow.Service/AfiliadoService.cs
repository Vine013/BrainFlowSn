using BrainFlow.Model;
using BrainFlow.Repository.Interfaces;
using BrainFlow.Service.Interfaces;

namespace BrainFlow.Service
{
    public class AfiliadoService : IAfiliadoService
    {
        #region Conexoes
        private readonly IAfiliadoREP _afiliadoREP;
        #endregion

        #region Construtor
        public AfiliadoService(IAfiliadoREP afiliadoREP)
        {
            _afiliadoREP = afiliadoREP;
        }
        #endregion

        #region Metodos

        #region BuscarAfiliadosPendentes
        public async Task<IEnumerable<AfiliadoMOD>> BuscarAfiliadosPendentes()
        {
            // CD_STATUS 1 para PENDENTE
            return await _afiliadoREP.BuscarPorStatus(1);
        }
        #endregion

        #region AprovarAfiliado
        public async Task<bool> AprovarAfiliado(int cdAfiliado)
        {
            // CD_STATUS 2 para APROVADO
            var afiliado = new AfiliadoMOD { CdAfiliado = cdAfiliado, CdStatus = 2, DtAprovacao = System.DateTime.Now };
            return await _afiliadoREP.Editar(afiliado);
        }
        #endregion

        #region CadastrarAfiliado
        public async Task<int> CadastrarAfiliado(AfiliadoMOD afiliado)
        {
            // CD_STATUS 1 para PENDENTE
            afiliado.CdStatus = 1;
            return await _afiliadoREP.Cadastrar(afiliado);
        }
        #endregion

        #endregion
    }
}
