namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;
 
    
    public partial class Auditoria
    {
        public int IdAuditoria { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public string DescriacaoAnterior { get; set; }
        
        public string DescriacaoAtual { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int IdModuloMenuItem { get; set; }

        public virtual Usuario UsuarioCriacao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }

    }
}
