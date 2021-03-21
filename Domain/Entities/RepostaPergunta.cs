namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class RepostaPergunta
    {
        public int IdRepostaPergunta { get; set; }

        public int IdResposta { get; set; }

        public int IdPergunta { get; set; }

        public virtual Pergunta Pergunta { get; set; }

        public virtual Resposta Resposta { get; set; }
    }
}
