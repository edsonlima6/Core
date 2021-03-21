namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Comissao
    {
        public Comissao()
        {
            ComissaoUsuario = new HashSet<ComissaoUsuario>();
        }
        
        public int IdComissao { get; set; }

        public string Nome { get; set; }

   
        public string Descricao { get; set; }

        public int? Percentual { get; set; }

        public int? Tipo { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        
        public string Ativo { get; set; }
        
        public virtual ICollection<ComissaoUsuario> ComissaoUsuario { get; set; }
    }
}
