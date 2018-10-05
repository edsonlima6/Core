namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class HistoricoLoginUsuario
    {
        public int IdHistoricoLoginUsuario { get; set; }

        public DateTime DataAcesso { get; set; }
        
        public string IP { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
