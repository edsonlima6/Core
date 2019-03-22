namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;
   

    public partial class ControleSMS
    {
        public int IdControleSMS { get; set; }

        public int Telefone { get; set; }

        public DateTime DataEnvio { get; set; }

        public int StatusEnvio { get; set; }

        public string MensagemEnvio { get; set; }

        public DateTime? DataRetorno { get; set; }

        public int? StatusRetorno { get; set; }
        
        public string MensagemRetorno { get; set; }

        public int IdSMS { get; set; }

        public int IdCliente { get; set; }

        public int? IdIndicacao { get; set; }

        public virtual SMS SMS { get; set; }

        public virtual Indicacao Indicacao { get; set; }
        public Cliente Cliente { get; set; }
    }
}
