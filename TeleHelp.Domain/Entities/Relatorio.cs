namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Relatorio
    {
        public Relatorio()
        {
            ConsultaRelatorio = new HashSet<ConsultaRelatorio>();
        }
        public int IdRelatorio { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public int TipoFormato { get; set; }

        public int IdFuncionalidadePermissao { get; set; }

        public int IdModuloMenuItem { get; set; }
        
        public virtual ICollection<ConsultaRelatorio> ConsultaRelatorio { get; set; }
    }
}
