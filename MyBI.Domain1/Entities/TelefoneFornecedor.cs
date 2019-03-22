namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TelefoneFornecedor
    {
        public int IdTelefoneFornecedor { get; set; }

        public int DDD { get; set; }

        public int Numero { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int IdTipoTelefone { get; set; }

        public bool Ativo { get; set; }

        public int IdFornecedor { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
