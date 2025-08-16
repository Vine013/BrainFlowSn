using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("AFILIADO")]
    public class AfiliadoMOD
    {
        [Key]
        [Column("CD_AFILIADO")]
        public int CdAfiliado { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("NR_CPF_CNPJ")]
        public string NrCpfCnpj { get; set; }

        [Column("NO_RAZAO_SOCIAL")]
        public string NoRazaoSocial { get; set; }

        [Column("DT_SOLICITACAO")]
        public DateTime DtSolicitacao { get; set; }

        [Column("DT_APROVACAO")]
        public DateTime? DtAprovacao { get; set; }

        [Column("CD_STATUS")]
        [ForeignKey("StatusGeralMOD")]
        public int CdStatus { get; set; }

        public virtual UsuarioMOD UsuarioMOD { get; set; }
        public virtual StatusGeralMOD StatusGeralMOD { get; set; }
    }
}
