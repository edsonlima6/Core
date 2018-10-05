namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ControleSequencia
    {
        public int IdControleSequencia { get; set; }

        public string Nome { get; set; }

        public int Sequencia { get; set; }

        public DateTime DataReferencia { get; set; }
        
        public string Referencia { get; set; }

        public int TipoControle { get; set; }
    }
}
