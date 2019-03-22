namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Ligacao
    {
        public Ligacao()
        {
            SAT = new HashSet<SAT>();
        }
        
        public int IdLigacao { get; set; }

        public int? IdUsuario { get; set; }
        
        public string DataLigacao { get; set; }
        
        public string DataInicio { get; set; }
        
        public string DataFim { get; set; }
        
        public string Status { get; set; }
        
        public string TipoLigacao { get; set; }
        
        public string Motivo { get; set; }

        public int? IdIndicacao { get; set; }

        public virtual Indicacao Indicacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<SAT> SAT { get; set; }
    }
}
