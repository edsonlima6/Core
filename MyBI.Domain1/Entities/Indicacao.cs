namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Indicacao
    {
        public Indicacao()
        {
            AgendaUsuarioIndicacao = new HashSet<AgendaUsuarioIndicacao>();
            Cliente = new HashSet<Cliente>();
            ControleSMS = new HashSet<ControleSMS>();
            FilaUsuarioIndicacao = new HashSet<FilaUsuarioIndicacao>();
            HistoricoIndicacao = new HashSet<HistoricoIndicacao>();
            Ligacao = new HashSet<Ligacao>();
            PedidoVenda = new HashSet<PedidoVenda>();
            QuestionarioIndicacao = new HashSet<QuestionarioIndicacao>();
        }
        
        public int IdIndicacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public int? IdUsuarioCadastro { get; set; }
        
        public string NomeIndicacao { get; set; }
        
        public string Telefone { get; set; }
        
        public string Endereco { get; set; }
        
        public string Numero { get; set; }
        
        public string Complemento { get; set; }
        
        public string CEP { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string UF { get; set; }
        
        public string Email { get; set; }

        public int? TipoInteresse { get; set; }
        
        public string Observacao { get; set; }

        public int Status { get; set; }

        public int IdOrigem { get; set; }

        public int? IdUsuarioResponsavel { get; set; }
        
        public string TipoIndicacao { get; set; }
        
        public string ValorIndicacao { get; set; }
        
        public string codindicacao { get; set; }
        
        public string Celular { get; set; }

        public DateTime? DataAgendamento { get; set; }
        
        public string Sexo { get; set; }
        
        public virtual ICollection<AgendaUsuarioIndicacao> AgendaUsuarioIndicacao { get; set; }
        
        public virtual ICollection<Cliente> Cliente { get; set; }
        
        public virtual ICollection<ControleSMS> ControleSMS { get; set; }

        public virtual DetalheIndicacao DetalheIndicacao { get; set; }
        
        public virtual ICollection<FilaUsuarioIndicacao> FilaUsuarioIndicacao { get; set; }
        
        public virtual ICollection<HistoricoIndicacao> HistoricoIndicacao { get; set; }

        public virtual OrigemIndicacao OrigemIndicacao { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
        
        public virtual ICollection<Ligacao> Ligacao { get; set; }
        
        public virtual ICollection<PedidoVenda> PedidoVenda { get; set; }
        
        public virtual ICollection<QuestionarioIndicacao> QuestionarioIndicacao { get; set; }
    }
}
