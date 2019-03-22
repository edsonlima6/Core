namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ServicoProduto
    {
        public int IdServicoProduto { get; set; }

        public int IdServico { get; set; }

        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Servico Servico { get; set; }
    }
}
