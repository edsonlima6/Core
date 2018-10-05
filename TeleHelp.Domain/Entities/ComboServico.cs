namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ComboServico
    {
        public int IdComboServico { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorDesconto { get; set; }

        public bool Ativo { get; set; }

        public int IdCombo { get; set; }

        public int IdServico { get; set; }

        public virtual Combo Combo { get; set; }

        public virtual Servico Servico { get; set; }
    }
}
