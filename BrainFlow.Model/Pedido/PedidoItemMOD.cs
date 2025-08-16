using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("PEDIDO_ITEM")]
    public class PedidoItemMOD
    {
        [Key]
        [Column("CD_PEDIDO_ITEM")]
        public int CdPedidoItem { get; set; }

        [Column("CD_PEDIDO")]
        [ForeignKey("PedidoMOD")]
        public int CdPedido { get; set; }

        [Column("CD_CURSO")]
        [ForeignKey("CursoMOD")]
        public int CdCurso { get; set; }

        [Column("DC_VALOR_ITEM")]
        public decimal DcValorItem { get; set; }

        public virtual PedidoMOD PedidoMOD { get; set; }
        public virtual CursoMOD CursoMOD { get; set; }
    }
}
