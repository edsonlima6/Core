using System.Collections.Generic;

namespace TeleHelp.Domain.Entities
{


    public class Acao
    {
        public Acao()
        {
            //HistoricoIndicacao = new HashSet<HistoricoIndicacao>();
        }
        public int IdAcao { get; set; }

        public string NomeAcao { get; set; }

        public int TipoAcao { get; set; }

        public bool Produtiva { get; set; }

        public int? IdAgenda { get; set; }

        //public virtual Agenda Agenda { get; set; }

        //public virtual ICollection<HistoricoIndicacao> HistoricoIndicacao { get; set; }
    }
}
