namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class HistoricoSAT
    {
        public int IdHistoricoSAT { get; set; }

        public DateTime DataHistorico { get; set; }
        
        public string Observacao { get; set; }

        public int Status { get; set; }

        public int IdSAT { get; set; }

        public int IdUsuario { get; set; }

        public virtual SAT SAT { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
