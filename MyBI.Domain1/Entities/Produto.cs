namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Produto
    {
        public Produto()
        {
            EstoquePacoteProduto = new HashSet<EstoquePacoteProduto>();
            EstoqueProduto = new HashSet<EstoqueProduto>();
            NotaFiscalImposto = new HashSet<NotaFiscalImposto>();
            OrcamentoVenda = new HashSet<OrcamentoVenda>();
            PedidoProduto = new HashSet<PedidoProduto>();
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
            ServicoProduto = new HashSet<ServicoProduto>();
        }
        
        public int IdProduto { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int IdTipoProduto { get; set; }

        public int? IdTipoLinhaProduto { get; set; }
        
        public string Modelo { get; set; }

        public int IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
        
        public virtual ICollection<EstoquePacoteProduto> EstoquePacoteProduto { get; set; }
        
        public virtual ICollection<EstoqueProduto> EstoqueProduto { get; set; }
        
        public virtual ICollection<NotaFiscalImposto> NotaFiscalImposto { get; set; }
        
        public virtual ICollection<OrcamentoVenda> OrcamentoVenda { get; set; }
        
        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
        
        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        
        public virtual ICollection<ServicoProduto> ServicoProduto { get; set; }
    }
}
