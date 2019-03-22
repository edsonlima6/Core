namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class MenuTela
    {
        public MenuTela()
        {
            //Menu = new HashSet<Menu>();
            //Tela = new HashSet<Tela>();
        }

        public int IdMenu { get; set; }
        
        public int IdTela { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataCadastro { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Tela Tela { get; set; }
    }
}
