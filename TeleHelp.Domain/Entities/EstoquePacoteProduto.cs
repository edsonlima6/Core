namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EstoquePacoteProduto
    {
        public int IdEstoquePacoteProduto { get; set; }

        public string NotaFiscal { get; set; }
        
        public string CodigoBarras { get; set; }

        public int IdProduto { get; set; }

        public int IdEstoquePacote { get; set; }

        public virtual EstoquePacote EstoquePacote { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
