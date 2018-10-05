namespace TeleHelp.Domain.Entities
{
    using System;



    public partial class AgendaUsuarioIndicacao
    {
        public int IdAgendaUsuario { get; set; }

        public DateTime DataAgenda { get; set; }

        public string Observacao { get; set; }

        public int StatusAgenda { get; set; }

        public int IdUsuario { get; set; }

        public int IdIndicacao { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Indicacao Indicacao { get; set; }
    }
}
