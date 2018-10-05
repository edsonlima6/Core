namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class OperacaoBanco
    {
        public OperacaoBanco()
        {
            ControleBanco = new HashSet<ControleBanco>();
        }
        
        public int IdOperacaoBanco { get; set; }

        public int TipoOperacao { get; set; }

        public int Ativo { get; set; }

        public int IdBanco { get; set; }

        public virtual Banco Banco { get; set; }
        
        public virtual ICollection<ControleBanco> ControleBanco { get; set; }
    }
}
