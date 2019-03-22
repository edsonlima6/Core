namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Tela
    {
        public Tela()
        {
            FuncionalidadeTela = new HashSet<FuncionalidadeTela>();
            MenuTela = new HashSet<MenuTela>();
            PermissaoTela = new HashSet<PermissaoTela>();
        }
        
        public int IdTela { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public virtual ICollection<FuncionalidadeTela> FuncionalidadeTela { get; set; }
        
        public virtual ICollection<MenuTela> MenuTela { get; set; }
        
        public virtual ICollection<PermissaoTela> PermissaoTela { get; set; }
    }
}
