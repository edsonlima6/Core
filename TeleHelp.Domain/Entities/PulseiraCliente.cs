namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PulseiraCliente
    {
        public int IdPulseiraCliente { get; set; }
        
        public string NomePulseira { get; set; }
        
        public string Impresso { get; set; }

        public DateTime? DataImpressao { get; set; }
        
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public int IdTipoPulsiera { get; set; }

        public int TamanhoPulseira { get; set; }

        public int CorPulseira { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
