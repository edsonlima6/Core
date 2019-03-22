namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Grupo
    {
        public Grupo()
        {
            GrupoUsuario = new HashSet<GrupoUsuario>();
            PermissaoTela = new HashSet<PermissaoTela>();
        }
        
        public int IdGrupo { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<GrupoUsuario> GrupoUsuario { get; set; }
        
        public virtual ICollection<PermissaoTela> PermissaoTela { get; set; }
    }
}
