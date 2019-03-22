namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;
   
    public partial class AssistenciaMedica
    {
     
        public AssistenciaMedica()
        {
            //AssistenciaMedicaHospital = new HashSet<AssistenciaMedicaHospital>();
        }
        public int IdAssistenciaMedica { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<AssistenciaMedicaHospital> AssistenciaMedicaHospital { get; set; }
    }
}
