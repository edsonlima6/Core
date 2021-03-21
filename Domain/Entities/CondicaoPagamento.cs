namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class CondicaoPagamento
    {
        public CondicaoPagamento()
        {
            OrcamentoVenda = new HashSet<OrcamentoVenda>();
        }
        
        public int IdCondicaoPagamento { get; set; }

        public string Nome { get; set; }

     
        public string Descricao { get; set; }

        public int TipoVencimento { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<OrcamentoVenda> OrcamentoVenda { get; set; }
    }
}
