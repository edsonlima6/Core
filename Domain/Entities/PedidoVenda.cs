namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PedidoVenda
    {
        public PedidoVenda()
        {
            OrcamentoVenda = new HashSet<OrcamentoVenda>();
            TituloCliente = new HashSet<TituloCliente>();
        }
        
        public int IdPedidoVenda { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal ValorTotal { get; set; }

        public int Instalado { get; set; }

        public DateTime? DataInstalacao { get; set; }

        public int Status { get; set; }

        public int IdUsuario { get; set; }

        public int IdCliente { get; set; }

        public int? IdIndicacao { get; set; }

        public virtual Indicacao Indicacao { get; set; }
        
        public virtual ICollection<OrcamentoVenda> OrcamentoVenda { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<TituloCliente> TituloCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
