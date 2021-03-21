namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EnderecoBanco
    {
        public int IdEnderecoBanco { get; set; }

        public int Agencia { get; set; }
        
        public string Conta { get; set; }

        public int? Carteira { get; set; }
        
        public string Especie { get; set; }
        
        public string Aceite { get; set; }
        
        public string Cedente { get; set; }
        
        public string ModeloArquivo { get; set; }
        
        public string Endereco { get; set; }
        
        public string Numero { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }

        public int? CEP { get; set; }

        public int UF { get; set; }
        
        public string Gerente1 { get; set; }
        
        public string Gerente2 { get; set; }

        public bool Ativo { get; set; }

        public int IdBanco { get; set; }

        public virtual Banco Banco { get; set; }
    }
}
