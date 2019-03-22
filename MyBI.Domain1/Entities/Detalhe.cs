namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Detalhe
    {
        public Detalhe()
        {
            //DetalheServico = new HashSet<DetalheServico>();
        }
        
        public int IdDetalhe { get; set; }

        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public int TipoDetalhe { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<DetalheServico> DetalheServico { get; set; }
    }
}
