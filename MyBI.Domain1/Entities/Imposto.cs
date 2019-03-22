namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Imposto
    {
        public Imposto()
        {
            NotaFiscalImposto = new HashSet<NotaFiscalImposto>();
        }
        
        public int IdImposto { get; set; }
        
        public string Nome { get; set; }

        public decimal BaseCalculo { get; set; }

        public int TipoImposto { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<NotaFiscalImposto> NotaFiscalImposto { get; set; }
    }
}
