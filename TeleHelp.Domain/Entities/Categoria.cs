using System;
using System.Collections.Generic;
namespace TeleHelp.Domain.Entities
{

    public class Categoria
    {

        public Categoria()
        {
            //Produto = new HashSet<Produto>();
        }

        
        public int IdCategoria { get; set; }

        public string Nome { get; set; }

  
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<Produto> Produto { get; set; }
    }
}
