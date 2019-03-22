namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Combo
    {
        public Combo()
        {
            ComboServico = new HashSet<ComboServico>();
        }
        public int IdCombo { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<ComboServico> ComboServico { get; set; }
    }
}
