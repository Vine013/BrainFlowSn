using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("USUARIO_AULA")]
    public class UsuarioAulaMOD
    {
        [Key]
        [Column("CD_USUARIO_AULA")]
        public int CdUsuarioAula { get; set; }

        [Column("CD_AULA")]
        [ForeignKey("AulaMOD")]
        public int CdAula { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("SN_CONCLUIDA")]
        public string SnConcluida { get; set; }

        [Column("DT_CONCLUSAO")]
        public DateTime? DtConclusao { get; set; }

        public virtual AulaMOD AulaMOD { get; set; }
        public virtual UsuarioMOD UsuarioMOD { get; set; }
    }
}
