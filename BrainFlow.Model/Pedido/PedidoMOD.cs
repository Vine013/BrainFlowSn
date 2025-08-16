using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("PEDIDO")]
    public class PedidoMOD
    {
        [Key]
        [Column("CD_PEDIDO")]
        public int CdPedido { get; set; }

        [Column("CD_USUARIO")]
        [ForeignKey("UsuarioMOD")]
        public int CdUsuario { get; set; }

        [Column("DC_VALOR_TOTAL")]
        public decimal DcValorTotal { get; set; }

        [Column("DT_PEDIDO")]
        public DateTime DtPedido { get; set; }

        [Column("CD_STATUS")]
        [ForeignKey("StatusGeralMOD")]
        public int CdStatus { get; set; }

        public virtual UsuarioMOD UsuarioMOD { get; set; }
        public virtual StatusGeralMOD StatusGeralMOD { get; set; }
    }
}
