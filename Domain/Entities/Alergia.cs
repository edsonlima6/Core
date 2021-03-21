namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class Alergia
    {
        public Alergia()
        {
            AlergiaCliente = new HashSet<AlergiaCliente>();
        }
        
        public int IdAlergia { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int TipoAlergia { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<AlergiaCliente> AlergiaCliente { get; set; }
    }
}
