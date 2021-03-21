namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class Bonificacao
    {
        public Bonificacao()
        {
            //BonificacaoCliente = new HashSet<BonificacaoCliente>();
        }
        
        public int IdBonificacao { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int TipoBonificacao { get; set; }

        public int Periodo { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<BonificacaoCliente> BonificacaoCliente { get; set; }
    }
}
