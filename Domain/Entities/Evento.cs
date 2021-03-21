namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Evento
    {
        public Evento()
        {
            EventoCliente = new HashSet<EventoCliente>();
        }
        
        public int IdEvento { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public int Tipo { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<EventoCliente> EventoCliente { get; set; }
    }
}
