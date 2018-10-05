using System;
using System.Collections.Generic;

namespace TeleHelp.Domain.Entities
{
    public class Servico
    {
        public Servico()
        {
            //Atendimento = new HashSet<Atendimento>();
            BloqueioServico = new HashSet<BloqueioServico>();
            ComboServico = new HashSet<ComboServico>();
            //DetalheServico = new HashSet<DetalheServico>();
            //ServicoUnidadeCliente = new HashSet<ServicoUnidadeCliente>();
            //ServicoProduto = new HashSet<ServicoProduto>();
        }
        
        public int IdServico { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public decimal ValorMensal { get; set; }

        public decimal ValorAnual { get; set; }

        public int IdTipoServico { get; set; }

        public bool Ativo { get; set; }
        
        //public virtual ICollection<Atendimento> Atendimento { get; set; }
        
        public virtual ICollection<BloqueioServico> BloqueioServico { get; set; }
        
        public virtual ICollection<ComboServico> ComboServico { get; set; }
        
        //public virtual ICollection<DetalheServico> DetalheServico { get; set; }
        
        //public virtual ICollection<ServicoUnidadeCliente> ServicoUnidadeCliente { get; set; }
        
        //public virtual ICollection<ServicoProduto> ServicoProduto { get; set; }
    }
}
