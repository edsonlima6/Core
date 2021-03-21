namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TipoEmail
    {
        public TipoEmail()
        {
            EmailCliente = new HashSet<EmailCliente>();
        }
        
        public int IdTipoEmail { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public virtual ICollection<EmailCliente> EmailCliente { get; set; }
    }
}
