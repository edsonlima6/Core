namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class OrcamentoVenda
    {
        public int IdOrcamentoVenda { get; set; }

        public int Ordem { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public decimal? Desconto { get; set; }

        public DateTime DataOrcamento { get; set; }

        public int? OrigemOrcamento { get; set; }
        
        public string Dealer { get; set; }

        public int IdPedidoVenda { get; set; }

        public int IdProduto { get; set; }

        public int IdCondicaoPagamento { get; set; }

        public virtual CondicaoPagamento CondicaoPagamento { get; set; }

        public virtual PedidoVenda PedidoVenda { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
