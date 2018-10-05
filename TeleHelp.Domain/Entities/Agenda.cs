
using System;
using System.Collections.Generic;

namespace TeleHelp.Domain.Entities
{
    public class Agenda
    {
        public Agenda()
        {
            //Acao = new HashSet<Acao>();
        }

        public int IdAgenda { get; set; }

 
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int TipoAgenda { get; set; }

        public int Periodo { get; set; }

        public bool Ativo { get; set; }
        //public virtual ICollection<Acao> Acao { get; set; }
    }
}
