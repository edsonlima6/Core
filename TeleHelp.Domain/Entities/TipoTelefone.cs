namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TipoTelefone
    {
        public TipoTelefone()
        {
            TelefoneCliente = new HashSet<TelefoneCliente>();
            TelefoneEmpresa = new HashSet<TelefoneEmpresa>();
            TelefoneFornecedor = new HashSet<TelefoneFornecedor>();
        }
        
        public int IdTipoTelefone { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public virtual ICollection<TelefoneCliente> TelefoneCliente { get; set; }
        public virtual ICollection<TelefoneEmpresa> TelefoneEmpresa { get; set; }
        public virtual ICollection<TelefoneFornecedor> TelefoneFornecedor { get; set; }
    }
}
