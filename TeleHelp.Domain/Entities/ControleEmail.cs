namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class ControleEmail
    {
        public int IdControleEmail { get; set; }

        public string Email { get; set; }

        public DateTime DataEnvio { get; set; }

        public int IdUsuarioEnvio { get; set; }
        
        public string MensagemEnvio { get; set; }

        public int IdEmail { get; set; }

        public int IdCliente { get; set; }

        public int IdStatusControleEmail { get; set; }

        public int IdUsuarioAgenda { get; set; }

        public virtual Email Email1 { get; set; }

        public virtual StatusControleEmail StatusControleEmail { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Cliente Cliente { get; set; }
    }
}
