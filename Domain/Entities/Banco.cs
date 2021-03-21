namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    
    public partial class Banco
    {
        public Banco()
        {
            ContaCliente = new HashSet<ContaCliente>();
            //EnderecoBanco = new HashSet<EnderecoBanco>();
            //InconsistenciaBanco = new HashSet<InconsistenciaBanco>();
            //OperacaoBanco = new HashSet<OperacaoBanco>();
        }
        
        public int IdBanco { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; }

 
        public string NomeFantasia { get; set; }
        
        public virtual ICollection<ContaCliente> ContaCliente { get; set; }
        
        //public virtual ICollection<EnderecoBanco> EnderecoBanco { get; set; }
        
        //public virtual ICollection<InconsistenciaBanco> InconsistenciaBanco { get; set; }
        
        //public virtual ICollection<OperacaoBanco> OperacaoBanco { get; set; }
    }
}
