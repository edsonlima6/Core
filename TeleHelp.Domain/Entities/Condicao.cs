namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Condicao
    {
        public Condicao()
        {
            CondicaoCliente = new HashSet<CondicaoCliente>();
        }
        
        public int IdCondicao { get; set; }

        public string Nome { get; set; }

    
        public string Descricao { get; set; }

        public int TipoCondicao { get; set; }

        public int Ativo { get; set; }
        
        public virtual ICollection<CondicaoCliente> CondicaoCliente { get; set; }
    }
}
