namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class LembreteContatoCliente
    {
        public int IdLembreteContatoCliente { get; set; }
        
        public string NomeContato { get; set; }

        public int TipoAlerta { get; set; }

        public int TipoDado { get; set; }

        public DateTime? DataInativou { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public int IdCliente { get; set; }

        public int IdLembreteMedicamentoCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual LembreteMedicamentoCliente LembreteMedicamentoCliente { get; set; }
    }
}
