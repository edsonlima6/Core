namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class TelefoneEmpresa
    {
        public int IdTelefoneEmpresa { get; set; }

        public int DDD { get; set; }

        public int Numero { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int IdTipoTelefone { get; set; }

        public int IdEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
