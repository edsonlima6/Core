namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ComissaoUsuario
    {
        public int IdComissaoUsuario { get; set; }

        public DateTime DataLiberacao { get; set; }

        public DateTime DataComissao { get; set; }

        public decimal ValorComissao { get; set; }

        public int PercentualComissao { get; set; }

        public int Status { get; set; }

        public int IdTituloCliente { get; set; }

        public int IdUsuario { get; set; }

        public int IdComissao { get; set; }

        public virtual Comissao Comissao { get; set; }

        public virtual TituloCliente TituloCliente { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
