namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ContatoCliente
    {
        public int IdContatoCliente { get; set; }

        public DateTime DataContato { get; set; }
        
        public string Descricao { get; set; }

        public int TipoContato { get; set; }

        public int Status { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
