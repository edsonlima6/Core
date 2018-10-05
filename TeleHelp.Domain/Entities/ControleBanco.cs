namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ControleBanco
    {
        public int IdControleBanco { get; set; }

        public DateTime DataEnvio { get; set; }

        public DateTime DataVencimento { get; set; }

        public decimal DataPagamento { get; set; }

        public decimal ValoPago { get; set; }

        public decimal? ValorJuros { get; set; }

        public decimal? ValorMulta { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorTaxa { get; set; }

        public decimal? ValorEncargos { get; set; }

        public int Status { get; set; }

        public int IdTituloCliente { get; set; }

        public int TipoControleBanco { get; set; }

        public int? IdInconsistenciaBanco { get; set; }

        public int IdControleArquivo { get; set; }

        public int IdOperacaoBanco { get; set; }

        public virtual ControleArquivo ControleArquivo { get; set; }

        public virtual InconsistenciaBanco InconsistenciaBanco { get; set; }

        public virtual OperacaoBanco OperacaoBanco { get; set; }

        public virtual TituloCliente TituloCliente { get; set; }
    }
}
