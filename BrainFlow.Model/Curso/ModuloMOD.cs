using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("MODULO")]
    public class ModuloMOD
    {
        [Key]
        [Column("CD_MODULO")]
        public int CdModulo { get; set; }

        [Column("CD_CURSO")]
        [ForeignKey("CursoMOD")]
        public int CdCurso { get; set; }

        [Column("NO_MODULO")]
        public string NoModulo { get; set; }

        [Column("NR_ORDEM")]
        public int NrOrdem { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime DtCadastro { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime? DtAlteracao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        public virtual CursoMOD CursoMOD { get; set; }
    }
}
