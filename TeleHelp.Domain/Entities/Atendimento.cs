namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Atendimento
    {
        public int IdAtendimento { get; set; }

        public int IdSolicitacao { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public int IdServico { get; set; }

        public int? IdTipoLocalQueda { get; set; }

        public int IdTipoFinalizaAtendimento { get; set; }

        public int NotaAtendimento { get; set; }
        
        public string Observacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int IdTipoAtendimento { get; set; }

        public virtual Servico Servico { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
    }
}
