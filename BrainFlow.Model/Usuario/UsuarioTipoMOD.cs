using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainFlow.Model
{
    [Table("USUARIO_TIPO")]
    public class UsuarioTipoMOD
    {
        [Key]
        [Column("CD_TIPO_USUARIO")]
        public int CdTipoUsuario { get; set; }

        [Column("NO_TIPO_USUARIO")]
        public string NoTipoUsuario { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        [Column("CD_USUARIO_ALTEROU")]
        public string? CdUsuarioAlterou { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DtAlteracao { get; set; }
    }
}
