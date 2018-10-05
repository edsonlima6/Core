namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class RamalUsuario
    {
        public int IdRamalUsuario { get; set; }

        public int Ramal { get; set; }

        public int? DDD { get; set; }

        public int? Telefone { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
