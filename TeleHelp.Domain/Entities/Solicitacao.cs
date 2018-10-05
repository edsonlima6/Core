namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Solicitacao
    {
        public Solicitacao()
        {
            Atendimento = new HashSet<Atendimento>();
        }
        
        public int IdSolicitacao { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<Atendimento> Atendimento { get; set; }
    }
}
