namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EnderecoCliente
    {
        public EnderecoCliente()
        {
            //CartaoDroRaia = new HashSet<CartaoDroRaia>();
        }
        
        public int IdEnderecoCliente { get; set; }
        
        public string Endereco { get; set; }
        
        public string Complemento { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
        
        public string CEP { get; set; }
        
        public string UF { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        public int IdCliente { get; set; }

        public int IdTipoEndereco { get; set; }
        
        //public virtual ICollection<CartaoDroRaia> CartaoDroRaia { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual TipoEndereco TipoEndereco { get; set; }
    }
}
