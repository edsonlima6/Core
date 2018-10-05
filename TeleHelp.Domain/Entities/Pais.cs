namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    

    public partial class Pais
    {
        public Pais()
        {
            Estado = new HashSet<Estado>();
        }
        
        public int IdPais { get; set; }
        
        public string Nome { get; set; }
        
        public string Sigla { get; set; }
        
        public string DDI { get; set; }
        
        public virtual ICollection<Estado> Estado { get; set; }
    }
}
