namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class QuestionarioPergunta
    {
        public int IdQuestionarioPergunta { get; set; }

        public int IdQuestionario { get; set; }

        public int IdPergunta { get; set; }

        public virtual Pergunta Pergunta { get; set; }

        public virtual Questionario Questionario { get; set; }
    }
}
