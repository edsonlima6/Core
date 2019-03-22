namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class GrauRelacao
    {
        public int IdGrauRelacao { get; set; }
        
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
