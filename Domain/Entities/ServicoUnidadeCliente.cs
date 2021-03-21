namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class ServicoUnidadeCliente
    {
        public int IdServicoUnidadeCliente { get; set; }

        public int Quantidade { get; set; }

        public decimal? ValorInicial { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorAtual { get; set; }

        public DateTime? DataCancelamento { get; set; }

        public bool Ativo { get; set; }

        public int? TipoDesconto { get; set; }

        public DateTime? DataUltimoAjuste { get; set; }
        
        public string PercentualReajuste { get; set; }
        
        public int IdServico { get; set; }
        
        public int IdCliente { get; set; }

        public int? IdUnidade { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Servico Servico { get; set; }

        public virtual Unidade Unidade { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
