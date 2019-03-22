namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EstoqueTransferencia
    {
        public int IdEstoqueTransferencia { get; set; }
        
        public string DataTransferencia { get; set; }
        
        public string TipoTransferencia { get; set; }

        public int? IdCliente { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdUsuarioReceptor { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
