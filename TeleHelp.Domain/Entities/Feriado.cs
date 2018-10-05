namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Feriado
    {
        public int IdFeriado { get; set; }
        
        public string DataFeriado { get; set; }
        
        public string Descricao { get; set; }
    }
}
