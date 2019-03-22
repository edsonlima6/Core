namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class OrigemIndicacao
    {
        public OrigemIndicacao()
        {
            Indicacao = new HashSet<Indicacao>();
        }
        
        public int IdOrigemIndicacao { get; set; }
        
        public string Nome { get; set; }

        public int Ativo { get; set; }
        
        public virtual ICollection<Indicacao> Indicacao { get; set; }
    }
}
