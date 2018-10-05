using System;
using System.Collections.Generic;

namespace TeleHelp.Domain.Entities
{

    public partial class Usuario
    {
        public Usuario()
        {
            //AgendaUsuarioIndicacao = new HashSet<AgendaUsuarioIndicacao>();
            //Atendimento = new HashSet<Atendimento>();
            //Auditoria = new HashSet<Auditoria>();
            //Auditoria1 = new HashSet<Auditoria>();
            //BonificacaoCliente = new HashSet<BonificacaoCliente>();
            //ComissaoUsuario = new HashSet<ComissaoUsuario>();
            //ContatoCliente = new HashSet<ContatoCliente>();
            //ControleArquivo = new HashSet<ControleArquivo>();
            //ControleEmail = new HashSet<ControleEmail>();
            //EstoqueTransferencia = new HashSet<EstoqueTransferencia>();
            //EstoqueTransferencia1 = new HashSet<EstoqueTransferencia>();
            //FilaUsuarioIndicacao = new HashSet<FilaUsuarioIndicacao>();
            //GrupoUsuario = new HashSet<GrupoUsuario>();
            //HistoricoLoginUsuario = new HashSet<HistoricoLoginUsuario>();
            //HistoricoSAT = new HashSet<HistoricoSAT>();
            //Indicacao = new HashSet<Indicacao>();
            //Indicacao1 = new HashSet<Indicacao>();
            //Ligacao = new HashSet<Ligacao>();
            //PedidoProduto = new HashSet<PedidoProduto>();
            //PedidoProduto1 = new HashSet<PedidoProduto>();
            //PedidoProduto2 = new HashSet<PedidoProduto>();
            //PedidoVenda = new HashSet<PedidoVenda>();
            //QuestionarioIndicacao = new HashSet<QuestionarioIndicacao>();
            //RamalUsuario = new HashSet<RamalUsuario>();
            //RepresentanteUsuario = new HashSet<RepresentanteUsuario>();
            //SAT = new HashSet<SAT>();
            //ServicoUnidadeCliente = new HashSet<ServicoUnidadeCliente>();
            //TituloCliente = new HashSet<TituloCliente>();
            //TituloCliente1 = new HashSet<TituloCliente>();
            //TituloCliente2 = new HashSet<TituloCliente>();
            //HistoricoIndicacao = new HashSet<HistoricoIndicacao>();
        }
        
        public int IdUsuario { get; set; }
        
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }
        
        public byte[] Foto { get; set; }

        //public int? Matricula { get; set; }

        //public int? Turno { get; set; }

        //public TimeSpan? HorarioEntrada { get; set; }

        //public TimeSpan? HorarioSaida { get; set; }

        //public int IdTipoUsuario { get; set; }

        //public int IdTipoPerfil { get; set; }

        //public int IdTipoAtendimento { get; set; }
        
        public string Email { get; set; }

        public bool Ativo { get; set; }

        //public int IdCargo { get; set; }

        //public int IdDepartamento { get; set; }
        
        public string Login { get; set; }
        
        public byte[] Senha { get; set; }
        

        public DateTime? DataAlteracao { get; set; }
        
        //public virtual ICollection<AgendaUsuarioIndicacao> AgendaUsuarioIndicacao { get; set; }
        
        //public virtual ICollection<Atendimento> Atendimento { get; set; }
        
        //public virtual ICollection<Auditoria> Auditoria { get; set; }
        
        //public virtual ICollection<Auditoria> Auditoria1 { get; set; }
        
        //public virtual ICollection<BonificacaoCliente> BonificacaoCliente { get; set; }

        //public virtual Cargo Cargo { get; set; }
        
        //public virtual ICollection<ComissaoUsuario> ComissaoUsuario { get; set; }
        
        //public virtual ICollection<ContatoCliente> ContatoCliente { get; set; }
        
        //public virtual ICollection<ControleArquivo> ControleArquivo { get; set; }
        
        //public virtual ICollection<ControleEmail> ControleEmail { get; set; }

        //public virtual Departamento Departamento { get; set; }
        
        //public virtual ICollection<EstoqueTransferencia> EstoqueTransferencia { get; set; }
        //public virtual ICollection<EstoqueTransferencia> EstoqueTransferencia1 { get; set; }
        
        //public virtual ICollection<FilaUsuarioIndicacao> FilaUsuarioIndicacao { get; set; }
        
        //public virtual ICollection<GrupoUsuario> GrupoUsuario { get; set; }
        
        //public virtual ICollection<HistoricoLoginUsuario> HistoricoLoginUsuario { get; set; }
        
        //public virtual ICollection<HistoricoSAT> HistoricoSAT { get; set; }
        
        //public virtual ICollection<Indicacao> Indicacao { get; set; }
        
        //public virtual ICollection<Indicacao> Indicacao1 { get; set; }
        
        //public virtual ICollection<Ligacao> Ligacao { get; set; }
        
        //public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
        
        //public virtual ICollection<PedidoProduto> PedidoProduto1 { get; set; }
        
        //public virtual ICollection<PedidoProduto> PedidoProduto2 { get; set; }
        
        //public virtual ICollection<PedidoVenda> PedidoVenda { get; set; }
        
        //public virtual ICollection<QuestionarioIndicacao> QuestionarioIndicacao { get; set; }
        
        //public virtual ICollection<RamalUsuario> RamalUsuario { get; set; }
        
        //public virtual ICollection<RepresentanteUsuario> RepresentanteUsuario { get; set; }
        
        //public virtual ICollection<SAT> SAT { get; set; }
        
        //public virtual ICollection<ServicoUnidadeCliente> ServicoUnidadeCliente { get; set; }
        
        //public virtual ICollection<TituloCliente> TituloCliente { get; set; }
        
        //public virtual ICollection<TituloCliente> TituloCliente1 { get; set; }
        
        //public virtual ICollection<TituloCliente> TituloCliente2 { get; set; }
        //public virtual ICollection<HistoricoIndicacao> HistoricoIndicacao { get; set; }


    }
}
