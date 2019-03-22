namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class AssistenciaMedicaHospital
    {
        public AssistenciaMedicaHospital()
        {
            PlanoSaudeCliente = new HashSet<PlanoSaudeCliente>();
        }
        
        public int IdAssistenciaMedicaHospital { get; set; }

        public int IdHospital { get; set; }

        public int IdAssistenciaMedica { get; set; }

        public virtual AssistenciaMedica AssistenciaMedica { get; set; }

        public virtual Hospital Hospital { get; set; }
        
        public virtual ICollection<PlanoSaudeCliente> PlanoSaudeCliente { get; set; }
    }
}
