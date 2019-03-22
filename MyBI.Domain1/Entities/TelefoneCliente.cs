namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class TelefoneCliente
    {
        public int IdTelefoneCliente { get; set; }

        public int DDD { get; set; }

        public int Numero { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int IdCliente { get; set; }

        public bool Ativo { get; set; }

        public int IdTipoTelefone { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
