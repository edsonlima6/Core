namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Unidade
    {
        public Unidade()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
            ServicoUnidadeCliente = new HashSet<ServicoUnidadeCliente>();
        }
        
        public int IdUnidade { get; set; }
        
        public string Codigo { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
        
        public virtual ICollection<ServicoUnidadeCliente> ServicoUnidadeCliente { get; set; }
    }
}
