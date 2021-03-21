namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class StatusControleEmail
    {
        public StatusControleEmail()
        {
            ControleEmail = new HashSet<ControleEmail>();
        }
        
        public int IdStatusControleEmail { get; set; }
        
        public string CodigoRetorno { get; set; }

        public int TipoRetorno { get; set; }
        
        public string Descricao { get; set; }
        
        public virtual ICollection<ControleEmail> ControleEmail { get; set; }
    }
}
