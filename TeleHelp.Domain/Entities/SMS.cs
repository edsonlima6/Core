namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;


    public partial class SMS
    {
        public SMS()
        {
            ControleSMS = new HashSet<ControleSMS>();
        }
        
        public int IdSMS { get; set; }
        
        public string Nome { get; set; }
        
        public string Servidor { get; set; }
        
        public string Usuario { get; set; }
        
        public string Senha { get; set; }
        
        public string Token { get; set; }
        
        public string Porta { get; set; }
        
        public string Mensagem { get; set; }

        public bool Ativo { get; set; }
        
        public virtual ICollection<ControleSMS> ControleSMS { get; set; }
    }
}
