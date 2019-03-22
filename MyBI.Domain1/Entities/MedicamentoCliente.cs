namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class MedicamentoCliente
    {
        public MedicamentoCliente()
        {
            LembreteMedicamentoCliente = new HashSet<LembreteMedicamentoCliente>();
        }
        
        public int IdMedicamentoCliente { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public TimeSpan? Horario { get; set; }

        public int? TipoUsoContinuo { get; set; }
        
        public string Dosagem { get; set; }
        
        public string Frequencia { get; set; }
        
        public string Periodicidade { get; set; }

        public int? Intervalo { get; set; }
        
        public string Observacao { get; set; }

        public int IdCliente { get; set; }

        public int IdMedicamento { get; set; }

        public virtual Cliente Cliente { get; set; }
        
        public virtual ICollection<LembreteMedicamentoCliente> LembreteMedicamentoCliente { get; set; }

        public virtual Medicamento Medicamento { get; set; }
    }
}
