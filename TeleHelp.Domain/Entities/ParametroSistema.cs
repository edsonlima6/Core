namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ParametroSistema
    {
        public int IdParametroSistema { get; set; }
        
        public string Nome { get; set; }
        
        public string Valor { get; set; }

        public int IdSistema { get; set; }

        public virtual Sistema Sistema { get; set; }
    }
}
