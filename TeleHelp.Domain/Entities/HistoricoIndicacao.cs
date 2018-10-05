namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class HistoricoIndicacao
    {
        public int IdHistoricoIndicacao { get; set; }

        public int? IdProtocoloIndicacao { get; set; }

        public DateTime? DataHistorico { get; set; }
        
        public string Descricao { get; set; }

        public int? TipoFilaOrigem { get; set; }

        public DateTime? DataAdicionado { get; set; }
        
        public string StatusAtendimento { get; set; }

        public DateTime? DataRetorno { get; set; }

        public int? PrioridadeIndicacao { get; set; }

        public int? TipoAtendimento { get; set; }

        public DateTime? DataPrimeiroAtendimento { get; set; }

        public DateTime? DataUltimoAtendimento { get; set; }

        public int? IdAcao { get; set; }

        public int IdUsuario { get; set; }

        public int IdIndicacao { get; set; }

        public virtual Indicacao Indicacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Acao Acao { get; set; }

    }
}
