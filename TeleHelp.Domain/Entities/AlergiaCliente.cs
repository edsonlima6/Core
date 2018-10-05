namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
   
    public partial class AlergiaCliente
    {
        public int IdAlergiaCliente { get; set; }

        public int IdCliente { get; set; }

        public int IdAlergia { get; set; }

        public bool Ativo { get; set; }
        
        public string Observacao { get; set; }

        public virtual Alergia Alergia { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
