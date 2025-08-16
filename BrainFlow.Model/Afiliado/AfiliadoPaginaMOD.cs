using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrainFlow.Model
{
    [Table("AFILIADO_PAGINA")]
    public class AfiliadoPaginaMOD
    {
        [Key]
        [Column("CD_PAGINA")]
        public int CdPagina { get; set; }

        [Column("CD_AFILIADO")]
        [ForeignKey("AfiliadoMOD")]
        public int CdAfiliado { get; set; }

        [Column("TX_LINK_PAGINA")]
        public string TxLinkPagina { get; set; }

        [Column("TX_TITULO")]
        public string TxTitulo { get; set; }

        [Column("TX_CAMINHO_BANNER")]
        public string TxCaminhoBanner { get; set; }

        [Column("TX_CAMINHO_LOGO")]
        public string TxCaminhoLogo { get; set; }

        [Column("TX_URL_LINKEDIN")]
        public string? TxUrlLinkedin { get; set; }

        [Column("TX_URL_YOUTUBE")]
        public string? TxUrlYoutube { get; set; }

        [Column("TX_URL_INSTAGRAM")]
        public string? TxUrlInstagram { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DtAlteracao { get; set; }

        public virtual AfiliadoMOD AfiliadoMOD { get; set; }
    }
}
