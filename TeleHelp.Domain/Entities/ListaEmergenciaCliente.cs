namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class ListaEmergenciaCliente
    {
        public int IdListaEmergenciaCliente { get; set; }
        
        public string NomeParente { get; set; }

        public int Telefone1 { get; set; }

        public int TipoTelefone1 { get; set; }

        public int? Telefone2 { get; set; }

        public int? TipoTelefone2 { get; set; }

        public int? Telefone3 { get; set; }

        public int? TipoTelefone3 { get; set; }

        public int? Telefone4 { get; set; }

        public int? TipoTelefone4 { get; set; }

        public int? Telefone5 { get; set; }

        public int? TipoTelefone5 { get; set; }
        
        public string Email { get; set; }

        public int TipoParentesco { get; set; }

        public int PossuiChaveResidencia { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
