namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Cidade
    {
        
        public Cidade()
        {
            //Cep = new HashSet<Cep>();
        }

        public int IdCidade { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string DDD { get; set; }

        public bool RT { get; set; }

        public int IdEstado { get; set; }

        //public virtual ICollection<Cep> Cep { get; set; }

        //public virtual Estado Estado { get; set; }
    }
}
