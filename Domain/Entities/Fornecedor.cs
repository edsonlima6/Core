namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Fornecedor
    {
        public Fornecedor()
        {
            EnderecoFornecedor = new HashSet<EnderecoFornecedor>();
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
            TelefoneFornecedor = new HashSet<TelefoneFornecedor>();
        }
        
        public int IdFornecedor { get; set; }
        
        public string RazaoSocial { get; set; }
        
        public string NomeFantasia { get; set; }

        public long CpfCnpj { get; set; }

        public int TipoPessoa { get; set; }
        
        public string NomeContato { get; set; }
        
        public string InscricaoEstadual { get; set; }
        
        public string InscricacaoMunicipal { get; set; }
        
        public string Observacao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<EnderecoFornecedor> EnderecoFornecedor { get; set; }
        
        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        
        public virtual ICollection<TelefoneFornecedor> TelefoneFornecedor { get; set; }
    }
}
