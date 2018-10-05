using System;
using System.Collections.Generic;
namespace TeleHelp.Domain.Entities
{
     public class Cliente
    {

        public Cliente()
        {
            //AlergiaCliente = new HashSet<AlergiaCliente>();
            //CartaoDroRaia = new HashSet<CartaoDroRaia>();
            //ClienteAdicional = new HashSet<Cliente>();
            //CondicaoCliente = new HashSet<CondicaoCliente>();
            //ContaCliente = new HashSet<ContaCliente>();
            //ContatoCliente = new HashSet<ContatoCliente>();
            //CoobrigadoCliente = new HashSet<CoobrigadoCliente>();
            //Servico = new HashSet<Servico>();
            //EmailCliente = new HashSet<EmailCliente>();
            //EnderecoCliente = new HashSet<EnderecoCliente>();
            //EventoCliente = new HashSet<EventoCliente>();
            //ServicoUnidadeCliente = new HashSet<ServicoUnidadeCliente>();
            //LembreteContatoCliente = new HashSet<LembreteContatoCliente>();
            //LembreteMedicamentoCliente = new HashSet<LembreteMedicamentoCliente>();
            //ListaEmergenciaCliente = new HashSet<ListaEmergenciaCliente>();
            //MedicamentoCliente = new HashSet<MedicamentoCliente>();
            //PlanoSaudeCliente = new HashSet<PlanoSaudeCliente>();
            //PulseiraCliente = new HashSet<PulseiraCliente>();
            //TelefoneCliente = new HashSet<TelefoneCliente>();
            //TituloCliente = new HashSet<TituloCliente>();
            //Atendimento = new HashSet<Atendimento>();
            //BonificacaoCliente = new HashSet<BonificacaoCliente>();
            //ControleEmail = new HashSet<ControleEmail>();
            //ControleSMS = new HashSet<ControleSMS>();
            //PedidoVenda = new HashSet<PedidoVenda>();
            //SATs = new HashSet<SAT>();
        }

        public int IdCliente { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public DateTime? DataNascimento { get; set; }


        public string CpfCnpj { get; set; }

        public string Rg { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? Genero { get; set; }

        public int EstadoCivil { get; set; }

        //public int IdTipoCliente { get; set; }

        //public int IdTipoPessoa { get; set; }

        //public int IdTipoParentesco { get; set; }

        public int Ativo { get; set; }

        //public int? IdClienteAdicional { get; set; }
        //public virtual Cliente ClienteAdicional{ get; set; }
        
        //public byte[] Imagem { get; set; }

        public string Codclie { get; set; }

        //public virtual ICollection<AlergiaCliente> AlergiaCliente { get; set; }

     
        //public virtual ICollection<CartaoDroRaia> CartaoDroRaia { get; set; }

        //public virtual ICollection<Cliente> Cliente1 { get; set; }

        //public virtual Deposito Deposito { get; set; }

        //public virtual Indicacao Indicacao { get; set; }

        //public virtual ICollection<SAT> SATs { get; set; }

        //public ICollection<ControleSMS> ControleSMS { get; set; }

        //public virtual ICollection<CondicaoCliente> CondicaoCliente { get; set; }
        
        //public virtual ICollection<ContaCliente> ContaCliente { get; set; }
        
        //public virtual ICollection<ContatoCliente> ContatoCliente { get; set; }
        //public virtual ICollection<CoobrigadoCliente> CoobrigadoCliente { get; set; }
        
        //public virtual ICollection<Servico> Servico { get; set; }
        
        //public virtual ICollection<EmailCliente> EmailCliente { get; set; }
        
        //public virtual ICollection<EnderecoCliente> EnderecoCliente { get; set; }
        
        //public virtual ICollection<EventoCliente> EventoCliente { get; set; }
        
        //public virtual ICollection<ServicoUnidadeCliente> ServicoUnidadeCliente { get; set; }

        //public virtual DetalheCliente DetalheCliente { get; set; }
        
        //public virtual ICollection<LembreteContatoCliente> LembreteContatoCliente { get; set; }
        
        //public virtual ICollection<LembreteMedicamentoCliente> LembreteMedicamentoCliente { get; set; }
        
        //public virtual ICollection<ListaEmergenciaCliente> ListaEmergenciaCliente { get; set; }
        
        //public virtual ICollection<MedicamentoCliente> MedicamentoCliente { get; set; }
        
        //public virtual ICollection<PlanoSaudeCliente> PlanoSaudeCliente { get; set; }
        
        //public virtual ICollection<PulseiraCliente> PulseiraCliente { get; set; }
        
        //public virtual ICollection<TelefoneCliente> TelefoneCliente { get; set; }
        
        //public virtual ICollection<TituloCliente> TituloCliente { get; set; }

        //public virtual ICollection<Atendimento>  Atendimento{ get; set; }

        //public virtual ICollection<BonificacaoCliente> BonificacaoCliente { get; set; }
                
        //public virtual ICollection<ControleEmail> ControleEmail { get; set; }
        //public virtual ICollection<PedidoVenda> PedidoVenda { get; set; }
    }
}
