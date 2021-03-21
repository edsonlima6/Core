namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Pergunta
    {
        public Pergunta()
        {
            QuestionarioPergunta = new HashSet<QuestionarioPergunta>();
            RepostaPergunta = new HashSet<RepostaPergunta>();
        }
        
        public int IdPergunta { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<QuestionarioPergunta> QuestionarioPergunta { get; set; }
        public virtual ICollection<RepostaPergunta> RepostaPergunta { get; set; }
    }
}
