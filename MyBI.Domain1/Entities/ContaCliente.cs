namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ContaCliente
    {
        public int IdContaCliente { get; set; }

        public int TipoConta { get; set; }

        public int Agencia { get; set; }
        
        public string NumeroCartao { get; set; }
        
        public string Conta { get; set; }

        public DateTime? DataValidade { get; set; }

        public int DiaCobranca { get; set; }

        public bool Ativo { get; set; }

        public int IdBanco { get; set; }

        public int IdCliente { get; set; }

        public virtual Banco Banco { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
