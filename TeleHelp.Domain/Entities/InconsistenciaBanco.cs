namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class InconsistenciaBanco
    {
        public InconsistenciaBanco()
        {
            ControleBanco = new HashSet<ControleBanco>();
        }
        
        public int IdInconsistenciaBanco { get; set; }
        
        public string CodigoInconsistencia { get; set; }
        
        public string CodigoOcorrencia { get; set; }
        
        public string Descricao { get; set; }

        public int? IdBanco { get; set; }

        public virtual Banco Banco { get; set; }
        
        public virtual ICollection<ControleBanco> ControleBanco { get; set; }
    }
}
