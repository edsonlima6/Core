namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class EstoquePacote
    {
        public EstoquePacote()
        {
            EstoquePacoteProduto = new HashSet<EstoquePacoteProduto>();
        }
        
        public int IdEstoquePacote { get; set; }
        
        public string NumeroLote { get; set; }

        public DateTime DataLote { get; set; }

        public int Status { get; set; }
        
        public virtual ICollection<EstoquePacoteProduto> EstoquePacoteProduto { get; set; }
    }
}
