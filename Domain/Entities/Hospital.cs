namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Hospital
    {
        public Hospital()
        {
            AssistenciaMedicaHospital = new HashSet<AssistenciaMedicaHospital>();
        }
        
        public int IdHospital { get; set; }
        
        public string Nome { get; set; }
        
        public string Endereco { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string CEP { get; set; }
        
        public string UF { get; set; }

        public int Numero { get; set; }
        
        public string Complemento { get; set; }
        
        public string Telefone { get; set; }
        
        public virtual ICollection<AssistenciaMedicaHospital> AssistenciaMedicaHospital { get; set; }
    }
}
