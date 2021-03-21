namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Menu
    {
        public Menu()
        {
            //Menu1 = new HashSet<Menu>();
            MenuTela = new HashSet<MenuTela>();
            
        }
        
        public int IdMenu { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public byte[] Imagem { get; set; }
        
        public string Caminho { get; set; }

        public bool Ativo { get; set; }

        public int IdSistema { get; set; }

        public int? IdMenuPai { get; set; }
        
        public virtual Menu Menu1 { get; set; }

        //public virtual Menu Menu2 { get; set; }
        
        public virtual ICollection<MenuTela> MenuTela { get; set; }

        public virtual Sistema  Sistema{ get; set; }

    }
}
