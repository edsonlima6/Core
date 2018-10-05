namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Departamento
    {
        public Departamento()
        {
            //RepresentanteUsuario = new HashSet<RepresentanteUsuario>();
            Usuario = new HashSet<Usuario>();
        }
        
        public int IdDepartamento { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<RepresentanteUsuario> RepresentanteUsuario { get; set; }
        
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
