namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TipoInteresse
    {
        public int IdTipoInteresse { get; set; }
        
        public string Nome { get; set; }

        public bool? Ativo { get; set; }
    }
}
