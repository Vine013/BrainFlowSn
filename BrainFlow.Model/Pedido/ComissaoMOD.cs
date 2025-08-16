using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("COMISSAO")]
    public class ComissaoMOD
    {
        [Key]
        [Column("CD_COMISSAO")]
        public int CdComissao { get; set; }

        [Column("CD_PEDIDO_ITEM")]
        [ForeignKey("PedidoItemMOD")]
        public int CdPedidoItem { get; set; }

        [Column("CD_AFILIADO")]
        [ForeignKey("AfiliadoMOD")]
        public int CdAfiliado { get; set; }

        [Column("DC_VALOR_BRUTO_VENDA")]
        public decimal DcValorBrutoVenda { get; set; }

        [Column("DC_COMISSAO_AFILIADO")]
        public decimal DcComissaoAfiliado { get; set; }

        [Column("CD_STATUS")]
        [ForeignKey("StatusGeralMOD")]
        public int CdStatus { get; set; }

        [Column("DT_CALCULO")]
        public DateTime DtCalculo { get; set; }

        [Column("DT_REPASSE")]
        public DateTime? DtRepasse { get; set; }

        public virtual PedidoItemMOD PedidoItemMOD { get; set; }
        public virtual AfiliadoMOD AfiliadoMOD { get; set; }
        public virtual StatusGeralMOD StatusGeralMOD { get; set; }
    }
}
