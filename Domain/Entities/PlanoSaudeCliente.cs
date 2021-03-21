namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class PlanoSaudeCliente
    {
        public int IdPlanoSaudeCliente { get; set; }

        public long Carteira { get; set; }
        
        public string Plano { get; set; }

        public int IdAssistenciaMedicaHospital { get; set; }

        public int IdCliente { get; set; }

        public virtual AssistenciaMedicaHospital AssistenciaMedicaHospital { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
