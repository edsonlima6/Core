namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PedidoProduto
    {
        public int IdPedidoProduto { get; set; }

        public DateTime DataEmissao { get; set; }

        public int IdUsuarioSolicitante { get; set; }

        public int IdUsuarioEmissor { get; set; }

        public int? IdUsuarioFinalizador { get; set; }

        public DateTime? DataFinalizacao { get; set; }

        public int IdProduto { get; set; }
        
        public string Observacao { get; set; }

        public int Prioridade { get; set; }

        public int Status { get; set; }

        public int? IdUnidade { get; set; }
        
        public string TipoDiscagem { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Unidade Unidade { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Usuario Usuario2 { get; set; }
    }
}
