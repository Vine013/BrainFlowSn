using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainFlow.Model
{
    [Table("USUARIO_LOGIN")]
    public class UsuarioLoginMOD
    {
        [Key]
        [Column("CD_USUARIO_LOGIN")]
        public int CdLogin { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("TX_SENHA_HASH")]
        public string TxSenhaHash { get; set; }

        [Column("TX_TOKEN")]
        public string? TxToken { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DtAlteracao { get; set; }

        public virtual UsuarioMOD UsuarioMOD { get; set; }
    }
}
