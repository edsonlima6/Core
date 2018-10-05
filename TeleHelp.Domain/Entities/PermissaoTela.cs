namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PermissaoTela
    {
        public PermissaoTela()
        {
            PermissaoFuncionalidade = new HashSet<PermissaoFuncionalidade>();
        }
        
        public virtual int IdPermissaoTela { get; set; }

        public int IdGrupo { get; set; }

        public int IdTela { get; set; }

        public bool Incluir { get; set; }

        public bool Alterar { get; set; }

        public bool Excluir { get; set; }

        public bool Consultar { get; set; }

        public virtual Grupo Grupo { get; set; }
        

        public virtual ICollection<PermissaoFuncionalidade> PermissaoFuncionalidade { get; set; }

        public virtual Tela Tela { get; set; }
    }
}
