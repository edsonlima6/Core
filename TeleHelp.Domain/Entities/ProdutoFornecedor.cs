namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ProdutoFornecedor
    {
        public int IdProdutoFornecedor { get; set; }

        public DateTime DataPrimeiroFornecimento { get; set; }

        public DateTime? DataUltimoFornecimento { get; set; }

        public int Periodo { get; set; }

        public bool Ativo { get; set; }

        public int IdFornecedor { get; set; }

        public int IdProduto { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
