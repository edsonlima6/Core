namespace  Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class DetalheIndicacao
    {
        public int IdIndicacao { get; set; }

        public DateTime? DataLigacao { get; set; }
        
        public string Status { get; set; }

        public DateTime? DataFinal { get; set; }

        public int? IdMotivoDesistencia { get; set; }
        
        public string Trimestral { get; set; }

        public int? Semana { get; set; }
        
        public string HoraDia { get; set; }
        
        public string Contato { get; set; }

        public DateTime? DataInclusaoSite { get; set; }

        public int? IdDesconto { get; set; }
        
        public string NumeroLinha { get; set; }
        
        public string TipoLinha { get; set; }
        
        public string CPF { get; set; }
        
        public string IndPropVend { get; set; }
        
        public string PessoaInteressada { get; set; }
        
        public string ControleLigacao { get; set; }

        public virtual Indicacao Indicacao { get; set; }
    }
}
