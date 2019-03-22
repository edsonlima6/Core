namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TipoEndereco
    {
        public TipoEndereco()
        {
            EnderecoCliente = new HashSet<EnderecoCliente>();
        }
        
        public int IdTipoEndereco { get; set; }
        
        public string Nome { get; set; }
        
        public string Sigla { get; set; }
        
        public virtual ICollection<EnderecoCliente> EnderecoCliente { get; set; }
    }
}
