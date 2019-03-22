namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class QuestionarioIndicacao
    {
        public int IdQuestionarioIndicacao { get; set; }

        public DateTime DataQuestionario { get; set; }

        public int IdIndicacao { get; set; }

        public int IdUsuario { get; set; }

        public int IdQuestionario { get; set; }

        public virtual Indicacao Indicacao { get; set; }

        public virtual Questionario Questionario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
