namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class BloqueioServico
    {
      
        public int IdBloqueioServico { get; set; }

     
        public string Hora { get; set; }

        public int Domingo { get; set; }

        public int Segunda { get; set; }

        public int Terca { get; set; }

        public int Quarta { get; set; }

        public int Quinta { get; set; }

        public int Sexta { get; set; }

        public int Sabado { get; set; }

        public int IdServico { get; set; }

        public virtual Servico Servico { get; set; }
    }
}
