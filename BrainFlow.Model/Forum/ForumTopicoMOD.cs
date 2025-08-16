using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("FORUM_TOPICO")]
    public class ForumTopicoMOD
    {
        [Key]
        [Column("CD_TOPICO")]
        public int CdTopico { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("NO_TOPICO")]
        public string NoTopico { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime DtCriacao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        public virtual UsuarioMOD UsuarioMOD { get; set; }
    }
}
