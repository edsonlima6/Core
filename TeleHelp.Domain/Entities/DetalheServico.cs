namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class DetalheServico
    {
        public int IdDetalheServico { get; set; }
        
        public string Valor { get; set; }

        public int IdCliente { get; set; }

        public int IdServico { get; set; }

        public int IdDetalhe { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Detalhe Detalhe { get; set; }

        public virtual Servico Servico { get; set; }
    }
}
