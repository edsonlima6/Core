namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            NotaFiscalImposto = new HashSet<NotaFiscalImposto>();
            TituloCliente = new HashSet<TituloCliente>();
        }
        
        public int IdNotaFiscal { get; set; }

        public string NotaFiscal1 { get; set; }
        
        public string Serie { get; set; }

        public DateTime DataNotaFiscal { get; set; }

        public int CodPrepFatura { get; set; }

        public int TipoNota { get; set; }

        public int Status { get; set; }

        public int TipoImpressa { get; set; }

        public decimal ValorTotalNota { get; set; }

        public int CFOP { get; set; }
        
        public string Observacao { get; set; }
        
        public virtual ICollection<NotaFiscalImposto> NotaFiscalImposto { get; set; }
        
        public virtual ICollection<TituloCliente> TituloCliente { get; set; }
    }
}
