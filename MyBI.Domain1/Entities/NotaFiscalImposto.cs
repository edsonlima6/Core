namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class NotaFiscalImposto
    {
        public int IdNotaFiscalImposto { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorImposto { get; set; }

        public int IdProduto { get; set; }

        public int IdNotaFiscal { get; set; }

        public int IdImposto { get; set; }

        public virtual Imposto Imposto { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
