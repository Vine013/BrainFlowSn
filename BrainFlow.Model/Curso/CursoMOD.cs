using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("CURSO")]
    public class CursoMOD
    {
        [Key]
        [Column("CD_CURSO")]
        public int CdCurso { get; set; }

        [Column("CD_AFILIADO")]
        [ForeignKey("AfiliadoMOD")]
        public int CdAfiliado { get; set; }

        [Column("NO_CURSO")]
        public string NoCurso { get; set; }

        [Column("TX_DESCRICAO")]
        public string TxDescricao { get; set; }

        [Column("DC_VALOR")]
        public decimal DcValor { get; set; }

        [Column("TX_CAMINHO_IMAGEM")]
        public string TxCaminhoImagem { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime DtCadastro { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime? DtAlteracao { get; set; }

        [Column("CD_STATUS")]
        [ForeignKey("StatusGeralMOD")]
        public int CdStatus { get; set; }

        public virtual AfiliadoMOD AfiliadoMOD { get; set; }
        public virtual StatusGeralMOD StatusGeralMOD { get; set; }
    }
}
