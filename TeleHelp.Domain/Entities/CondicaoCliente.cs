namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class CondicaoCliente
    {
        public int IdCondicaoCliente { get; set; }
        
        public string Observacao { get; set; }

        public int Ativo { get; set; }

        public int IdCondicao { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Condicao Condicao { get; set; }
    }
}
