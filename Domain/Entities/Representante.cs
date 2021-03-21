namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class Representante
    {
        public Representante()
        {
            RepresentanteUsuario = new HashSet<RepresentanteUsuario>();
        }

        public int IdRepresentante { get; set; }
        
        public string RazaoSocial { get; set; }

        public int CNPJ { get; set; }
        
        public string Endereco { get; set; }

        public int? Numero { get; set; }
        
        public string Cidade { get; set; }
        
        public string Bairro { get; set; }
        
        public string Complemento { get; set; }

        public int? CEP { get; set; }
        
        public string UF { get; set; }

        public int? DDD { get; set; }

        public int? Telefone { get; set; }
        
        public string Email { get; set; }
        
        public virtual ICollection<RepresentanteUsuario> RepresentanteUsuario { get; set; }
    }
}
