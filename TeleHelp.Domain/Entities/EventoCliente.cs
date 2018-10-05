namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EventoCliente
    {
        public int IdEventoCliente { get; set; }

        public DateTime DataEvento { get; set; }
        
        public string Observacao { get; set; }

        public int IdEvento { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Evento Evento { get; set; }
    }
}
