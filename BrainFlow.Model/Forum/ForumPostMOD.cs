using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("FORUM_POST")]
    public class ForumPostMOD
    {
        [Key]
        [Column("CD_POST")]
        public int CdPost { get; set; }

        [Column("CD_TOPICO")]
        [ForeignKey("ForumTopicoMOD")]
        public int CdTopico { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("TX_CONTEUDO")]
        public string TxConteudo { get; set; }

        [Column("DT_POSTAGEM")]
        public DateTime DtPostagem { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        public virtual ForumTopicoMOD ForumTopicoMOD { get; set; }
        public virtual UsuarioMOD UsuarioMOD { get; set; }
    }
}
