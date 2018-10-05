namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class BonificacaoCliente
    {
    
        public BonificacaoCliente()
        {
            BonificacaoTituloCliente = new HashSet<BonificacaoTituloCliente>();
        }

        
        public int IdBonificacaoCliente { get; set; }

        public DateTime DataGeracaoBonificacao { get; set; }

        public int QuantidadePrestacao { get; set; }

        public decimal ValorBonificadoTotal { get; set; }

        public int Status { get; set; }

        public int IdSAT { get; set; }

        public int IdCliente { get; set; }

        public int IdBonificacao { get; set; }

        public int IdUsuarioBonificacao { get; set; }

        public virtual Bonificacao Bonificacao { get; set; }
        
        public virtual ICollection<BonificacaoTituloCliente> BonificacaoTituloCliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Cliente Cliente { get; set; }
        
    }
}
