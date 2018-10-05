namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Reclamacao
    {
        public Reclamacao()
        {
            SAT = new HashSet<SAT>();
        }
        
        public int IdReclamacao { get; set; }
        
        public string Nome { get; set; }

        public int TipoReclamacao { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public int IdDepartamento { get; set; }
        
        public virtual ICollection<SAT> SAT { get; set; }
    }
}
