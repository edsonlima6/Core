namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
  
    public partial class Resposta
    {
        public Resposta()
        {
            RepostaPergunta = new HashSet<RepostaPergunta>();
        }
        
        public int IdResposta { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<RepostaPergunta> RepostaPergunta { get; set; }
    }
}
