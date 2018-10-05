namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TituloCliente
    {
        public TituloCliente()
        {
            BonificacaoTituloCliente = new HashSet<BonificacaoTituloCliente>();
            ComissaoUsuario = new HashSet<ComissaoUsuario>();
            ControleBanco = new HashSet<ControleBanco>();
        }
        
        public int IdTituloCliente { get; set; }
        
        public string CodigoTitulo { get; set; }

        public DateTime DataEmissao { get; set; }

        public int Tipo { get; set; }

        public int Prestacao { get; set; }

        public DateTime DataVencimento { get; set; }

        public decimal ValorDivida { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorJuros { get; set; }

        public decimal? ValorMulta { get; set; }

        public decimal? ValorEncargos { get; set; }

        public decimal? ValorTaxa { get; set; }

        public DateTime? DataPagamento { get; set; }

        public decimal? ValorPago { get; set; }

        public int Status { get; set; }

        public DateTime? DataBaixa { get; set; }

        public int? IdUsuarioBaixa { get; set; }

        public int? OrigemBaixa { get; set; }

        public int TipoNegociacao { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuarioEmissor { get; set; }

        public DateTime? DataCancelamento { get; set; }

        public int? IdUsuarioCancelamento { get; set; }

        public int IdPedidoVenda { get; set; }

        public int IdNotaFiscal { get; set; }
        
        public virtual ICollection<BonificacaoTituloCliente> BonificacaoTituloCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
        
        public virtual ICollection<ComissaoUsuario> ComissaoUsuario { get; set; }
        
        public virtual ICollection<ControleBanco> ControleBanco { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }

        public virtual PedidoVenda PedidoVenda { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
