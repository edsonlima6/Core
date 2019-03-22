namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Estado
    {
        public Estado()
        {
            //AliquotaICMS = new HashSet<AliquotaICMS>();
            //Cidade = new HashSet<Cidade>();
        }
        
        public int IdEstado { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int? IdPais { get; set; }
        
        //public virtual ICollection<AliquotaICMS> AliquotaICMS { get; set; }
        
        //public virtual ICollection<Cidade> Cidade { get; set; }

        //public virtual Pais Pais { get; set; }
    }
}
