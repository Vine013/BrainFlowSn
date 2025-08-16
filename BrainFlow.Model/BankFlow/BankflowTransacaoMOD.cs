using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("BANKFLOW_TRANSACAO")]
    public class BankflowTransacaoMOD
    {
        [Key]
        [Column("CD_TRANSACAO")]
        public int CdTransacao { get; set; }

        [Column("CD_PEDIDO")]
        [ForeignKey("PedidoMOD")]
        public int CdPedido { get; set; }

        [Column("TX_TOKEN_PAYPAL")]
        public string TxTokenPaypal { get; set; }

        [Column("DC_VALOR_TRANSACAO")]
        public decimal DcValorTransacao { get; set; }

        [Column("CD_TIPO_TRANSACAO")]
        [ForeignKey("BankflowTransacaoTipoMOD")]
        public int CdTipoTransacao { get; set; }

        [Column("DT_TRANSACAO")]
        public DateTime DtTransacao { get; set; }

        public virtual PedidoMOD PedidoMOD { get; set; }
        public virtual BankflowTransacaoTipoMOD BankflowTransacaoTipoMOD { get; set; }
    }
}
