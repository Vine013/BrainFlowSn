using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("AULA")]
    public class AulaMOD
    {
        [Key]
        [Column("CD_AULA")]
        public int CdAula { get; set; }

        [Column("CD_MODULO")]
        [ForeignKey("ModuloMOD")]
        public int CdModulo { get; set; }

        [Column("NO_AULA")]
        public string NoAula { get; set; }

        [Column("NR_ORDEM")]
        public int NrOrdem { get; set; }

        [Column("TX_DESCRICAO")]
        public string TxDescricao { get; set; }

        [Column("TX_CAMINHO_VIDEO")]
        public string TxCaminhoVideo { get; set; }

        [Column("SN_AULA_GRATUITA")]
        public string SnAulaGratuita { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime DtCadastro { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime? DtAlteracao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        public virtual ModuloMOD ModuloMOD { get; set; }
    }
}
