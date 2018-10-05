namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class RepresentanteUsuario
    {
        public int IdRepresentanteUsuario { get; set; }

        //public int IdDepartamento { get; set; }

        public int IdRepresentante { get; set; }

        public int IdUsuario { get; set; }

        public bool Ativo { get; set; }

        //public virtual Departamento Departamento { get; set; }

        public virtual Representante Representante { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
