namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class BonificacaoTituloCliente
    {
        public int IdBonificacaoTituloCliente { get; set; }

        public int NumeroPrestacao { get; set; }

        public DateTime DataBonificacao { get; set; }

        public decimal ValorPrestacao { get; set; }

        public int IdTituloCliente { get; set; }

        public int IdBonificacaoCliente { get; set; }

        public virtual BonificacaoCliente BonificacaoCliente { get; set; }

        public virtual TituloCliente TituloCliente { get; set; }
    }
}
