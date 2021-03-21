namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class LembreteMedicamentoCliente
    {
        public LembreteMedicamentoCliente()
        {
            LembreteContatoCliente = new HashSet<LembreteContatoCliente>();
        }
        
        public int IdLembreteMedicamentoCliente { get; set; }

        public DateTime DataInicioLembrete { get; set; }

        public DateTime? DataFimLembrete { get; set; }

        public TimeSpan? Horario { get; set; }

        public int? SEGUNDA { get; set; }

        public int? TERCA { get; set; }

        public int? QUARTA { get; set; }

        public int? QUINTA { get; set; }

        public int? SEXTA { get; set; }

        public int? SABADO { get; set; }

        public int? DOMINGO { get; set; }

        public int Ativo { get; set; }

        public DateTime? DataInivatacao { get; set; }

        public int IdCliente { get; set; }

        public int IdMedicamentoCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
        
        public virtual ICollection<LembreteContatoCliente> LembreteContatoCliente { get; set; }

        public virtual MedicamentoCliente MedicamentoCliente { get; set; }
    }
}
