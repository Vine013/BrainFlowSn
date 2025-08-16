using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainFlow.Model
{
    [Table("STATUS_GERAL")]
    public class StatusGeralMOD
    {
        [Key]
        [Column("CD_STATUS")]
        public int CdStatus { get; set; }

        [Column("NO_STATUS")]
        public string NoStatus { get; set; }

        [Column("TX_DESCRICAO")]
        public string TxDescricao { get; set; }

        [Column("CD_USUARIO_ALTEROU")]
        public string? CdUsuarioAlterou { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DtAlteracao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }
    }
}
