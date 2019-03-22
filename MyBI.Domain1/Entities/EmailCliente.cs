namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EmailCliente
    {
        public int IdEmailCliente { get; set; }
        
        public string Email { get; set; }

        public DateTime? DataCadastro { get; set; }

        public int IdCliente { get; set; }

        public int IdTipoEmail { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual TipoEmail TipoEmail { get; set; }
    }
}
