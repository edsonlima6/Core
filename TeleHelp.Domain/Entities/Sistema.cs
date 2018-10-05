namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Sistema
    {
        public Sistema()
        {
            //ParametroSistema = new HashSet<ParametroSistema>();
            Menu = new HashSet<Menu>();
        }
        
        public int IdSistema { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public int TipoSistema { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<ParametroSistema> ParametroSistema { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
