using System;
using System.Collections.Generic;


namespace MyBI.Domain1.Entities
{
    public class UnidadeCliente
    {
        #region Atributos
        public int IdUnidadeCliente { get; set; }
        public System.DateTime DataLiberacao { get; set; }
        public Nullable<System.DateTime> DataCancelamento { get; set; }
        public string DescricaoCancelamento { get; set; }
        public Nullable<System.DateTime> DataReativacao { get; set; }
        public int IdUnidade { get; set; }
        public int IdCliente { get; set; }
        public int TipoStatus { get; set; }
        public virtual ICollection<Atendimento> Atendimento { get; set; }
        //public virtual ICollection<BonificacaoUnidadeCliente> BonificacaoUnidadeCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ControleEmail> ControleEmail { get; set; }
        public virtual ICollection<ControleSMS> ControleSMS { get; set; }
        public virtual ICollection<PedidoVenda> PedidoVenda { get; set; }
        public virtual ICollection<SAT> SAT { get; set; }
        public virtual ICollection<ServicoUnidadeCliente> ServicoUnidadeCliente { get; set; }
        public virtual Unidade Unidade { get; set; }
        #endregion

        #region Construtores
        public UnidadeCliente()
        {
            this.Atendimento = new List<Atendimento>();
            //this.BonificacaoUnidadeCliente = new List<BonificacaoUnidadeCliente>();
            this.ControleEmail = new List<ControleEmail>();
            this.ControleSMS = new List<ControleSMS>();
            this.PedidoVenda = new List<PedidoVenda>();
            this.SAT = new List<SAT>();
            this.ServicoUnidadeCliente = new List<ServicoUnidadeCliente>();
        }
        #endregion

        #region Metodos
        #endregion
  
    }
}
