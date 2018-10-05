namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Cep
    {
    
        public int IdCep { get; set; }

        public string Bairro { get; set; }

     
        public string Inicial { get; set; }

        public string Final { get; set; }

        public int IdCidade { get; set; }

        //public virtual Cidade Cidade { get; set; }
    }
}
