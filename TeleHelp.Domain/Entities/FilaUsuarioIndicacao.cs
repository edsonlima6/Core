namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class FilaUsuarioIndicacao
    {
        public int IdFilaUsuarioIndicacao { get; set; }

        public int IdTipoFila { get; set; }

        public int Prioridade { get; set; }

        public int StatusFila { get; set; }

        public DateTime? DataUltimaAgenda { get; set; }

        public int IdIndicacao { get; set; }

        public int? IdUsuario { get; set; }
        
        public string DatinicioAtendimento { get; set; }
        
        public string DataFimAtendimento { get; set; }
        
        public string IdIndicacaoBaseAntiga { get; set; }
        
        public string TipoAtendimento { get; set; }
        
        public string StatusAtendimento { get; set; }

        public virtual Indicacao Indicacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
