namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Deposito
    {
        public Deposito()
        {
            Cliente = new HashSet<Cliente>();
        }
        
        public int IdDeposito { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
