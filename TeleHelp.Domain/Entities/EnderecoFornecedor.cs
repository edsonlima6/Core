namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class EnderecoFornecedor
    {
        public int IdEnderecoFornecedor { get; set; }
        
        public string Endereco { get; set; }
        
        public string Complemento { get; set; }

        public int Numero { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string UF { get; set; }
        
        public string CEP { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int TipoEndereco { get; set; }

        public bool Ativo { get; set; }

        public int IdFornecedor { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
