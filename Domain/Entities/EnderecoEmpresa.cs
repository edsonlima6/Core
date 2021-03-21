namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EnderecoEmpresa
    {
        public int IdEnderecoEmpresa { get; set; }
        
        public string Endereco { get; set; }
        
        public string Complemento { get; set; }

        public int Numero { get; set; }
        
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }
        
        public string UF { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int TipoEndereco { get; set; }

        public int IdEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
