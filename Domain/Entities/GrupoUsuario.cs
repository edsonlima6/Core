namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class GrupoUsuario
    {
        public int IdGrupoUsuario { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int IdGrupo { get; set; }

        public int IdUsuario { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
