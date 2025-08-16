using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("BANKFLOW_TRANSACAO_TIPO")]
    public class BankflowTransacaoTipoMOD
    {
        [Key]
        [Column("CD_TIPO_TRANSACAO")]
        public int CdTipoTransacao { get; set; }

        [Column("NO_TIPO_TRANSACAO")]
        public string NoTipoTransacao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DtAlteracao { get; set; }

        [Column("CD_USUARIO_ALTEROU")]
        public int? CdUsuarioAlterou { get; set; }
    }
}
