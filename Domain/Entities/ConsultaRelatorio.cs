namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ConsultaRelatorio
    {
        public int IdConsultaRelatorio { get; set; }

       
        public string Nome { get; set; }

        public int NumeroOrdem { get; set; }

        public string Descricao { get; set; }

        public int IdRelatorio { get; set; }

        public virtual Relatorio Relatorio { get; set; }
    }
}
