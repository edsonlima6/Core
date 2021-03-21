namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class FuncionalidadeTela
    {
        public FuncionalidadeTela()
        {
            PermissaoFuncionalidade = new HashSet<PermissaoFuncionalidade>();
        }
        
        public virtual int IdFuncionalidade { get; set; }
               
        public virtual string Nome { get; set; }
               
        public virtual string Descricao { get; set; }
               
        public virtual bool Ativo { get; set; }
               
        public virtual int IdTela { get; set; }
        
        public virtual ICollection<PermissaoFuncionalidade> PermissaoFuncionalidade { get; set; }

        public virtual Tela Tela { get; set; }
    }
}
