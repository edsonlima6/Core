namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class Medicamento
    {
        public Medicamento()
        {
            MedicamentoCliente = new HashSet<MedicamentoCliente>();
        }
        
        public int IdMedicamento { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public int TipoMedicamento { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<MedicamentoCliente> MedicamentoCliente { get; set; }
    }
}
