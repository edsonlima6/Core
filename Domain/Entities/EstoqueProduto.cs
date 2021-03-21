namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EstoqueProduto
    {
        public int IdEstoqueProduto { get; set; }
        
        public string CodUnidade { get; set; }

        public int QuantidadeAtual { get; set; }

        public decimal ValorAtual { get; set; }

        public int QuantidadeMamixa { get; set; }

        public int QuantidadeMinima { get; set; }

        public int Status { get; set; }

        public bool Ativo { get; set; }

        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
