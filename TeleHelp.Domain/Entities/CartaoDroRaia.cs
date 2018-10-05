namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class CartaoDroRaia
    {
        public int IdCartaoDroRaia { get; set; }

        public string Codigo { get; set; }

        public string Senha { get; set; }

        public bool Impresso { get; set; }

        public DateTime DataExportacao { get; set; }

        public int? QtdeViasEmitidas { get; set; }

        public int? StatusCartao { get; set; }

        public int IdEndereco { get; set; }

        public int? IdControleArquivo { get; set; }

        public int IdCliente { get; set; }

        public virtual ControleArquivo ControleArquivo { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual EnderecoCliente EnderecoCliente { get; set; }
    }
}
