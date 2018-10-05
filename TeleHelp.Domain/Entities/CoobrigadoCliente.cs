namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class CoobrigadoCliente
    {
        public int IdCoobrigado { get; set; }
        
        public string RazaoSocial { get; set; }
        
        public string InscricaoEstadual { get; set; }
        
        public string CpfCnpj { get; set; }

        public int TipoPessoa { get; set; }

        public int IdCliente { get; set; }

        public int? IdBanco { get; set; }
        
        public string Agencia { get; set; }
        
        public string NumeroCartao { get; set; }
        
        public string Conta { get; set; }
        
        public string DataValidade { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
