namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Email
    {
        public Email()
        {
            ControleEmail = new HashSet<ControleEmail>();
        }
        
        public int IdEmail { get; set; }
        
        public string Nome { get; set; }
        
        public string Servidor { get; set; }
        
        public string Email1 { get; set; }
        
        public string Senha { get; set; }
        
        public string SSL { get; set; }

        public int? Porta { get; set; }
        
        public string Assunto { get; set; }
        
        public string Mensagem { get; set; }

        public int TipoEmail { get; set; }
        
        public string Arquivo { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<ControleEmail> ControleEmail { get; set; }
    }
}
