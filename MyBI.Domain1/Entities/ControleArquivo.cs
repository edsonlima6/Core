namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ControleArquivo
    {
        public ControleArquivo()
        {
            CartaoDroRaia = new HashSet<CartaoDroRaia>();
            ControleBanco = new HashSet<ControleBanco>();
        }
        
        public int IdControleArquivo { get; set; }

        public int NumeroRemessa { get; set; }
        
        public string NomeArquivo { get; set; }

        public int Status { get; set; }

        public DateTime DataEnvio { get; set; }

        public DateTime? DataFinalizacao { get; set; }

        public int IdUsuario { get; set; }
        
        public virtual ICollection<CartaoDroRaia> CartaoDroRaia { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<ControleBanco> ControleBanco { get; set; }
    }
}
