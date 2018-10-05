namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Cargo
    {
        public Cargo()
        {
            Usuario = new HashSet<Usuario>();
        }
        
        public int IdCargo { get; set; }

    
        public string Nome { get; set; }

       
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        //public virtual int UsuarioId { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
