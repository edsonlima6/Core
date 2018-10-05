namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class SAT
    {
        public SAT()
        {
            HistoricoSAT = new HashSet<HistoricoSAT>();
        }
        
        public int IdSAT { get; set; }
        
        public string DataChamado { get; set; }

        public int TipoMotivo { get; set; }

        public int Status { get; set; }
        
        public string Observacao { get; set; }

        public int IdUsuario { get; set; }

        public int IdCliente { get; set; }

        public int IdReclamacao { get; set; }

        public int IdLigacao { get; set; }
        
        public virtual ICollection<HistoricoSAT> HistoricoSAT { get; set; }

        public virtual Ligacao Ligacao { get; set; }

        public virtual Reclamacao Reclamacao { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
