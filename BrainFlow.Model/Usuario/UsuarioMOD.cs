using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainFlow.Model
{
    [Table("USUARIO")]
    public class UsuarioMOD
    {
        [Key]
        [Column("CD_USUARIO")]
        public int CdUsuario { get; set; }

        [Column("CD_TIPO_USUARIO")]
        [ForeignKey("UsuarioTipoMOD")]
        public int CdTipoUsuario { get; set; }

        [Column("NO_USUARIO")]
        public string NoUsuario { get; set; }

        [Column("TX_EMAIL")]
        public string TxEmail { get; set; }

        [Column("TX_TELEFONE")]
        public string? TxTelefone { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime DtCadastro { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime? DtAlteracao { get; set; }

        [Column("SN_ATIVO")]
        public string SnAtivo { get; set; }

        public virtual UsuarioTipoMOD UsuarioTipoMOD { get; set; }
    }
}
