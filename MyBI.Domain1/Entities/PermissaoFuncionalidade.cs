namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PermissaoFuncionalidade
    {
        //public int IdPermissaoFuncionalidade { get; set; }
        public PermissaoFuncionalidade()
        {
            //FuncionalidadeTela = new HashSet<FuncionalidadeTela>();
            //PermissaoTela = new HashSet<PermissaoTela>();
        }

        public int IdPermissaoTela { get; set; }
        
        public int IdFuncionalidade { get; set; }

        public bool Permite { get; set; }
        
        public virtual FuncionalidadeTela FuncionalidadeTela { get; set; }

        public virtual PermissaoTela PermissaoTela { get; set; }
    }
}
