namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public partial class Questionario
    {
        public Questionario()
        {
            QuestionarioPergunta = new HashSet<QuestionarioPergunta>();
            QuestionarioIndicacao = new HashSet<QuestionarioIndicacao>();
        }
        
        public int IdQuestionario { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<QuestionarioPergunta> QuestionarioPergunta { get; set; }
        
        public virtual ICollection<QuestionarioIndicacao> QuestionarioIndicacao { get; set; }
    }
}
