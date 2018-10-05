namespace TeleHelp.Domain.Entities
{
    using System;
    using System.Collections.Generic;
 
    public class Empresa
    {
        public Empresa()
        {
            //TelefoneEmpresa = new HashSet<TelefoneEmpresa>();
        }

        public int idRazaoSocial { get; set; }

        public int idTipoEmpresa { get; set; }
        public string sRazaoSocial { get; set; }

        public DateTime dtCadastro { get; set; }
        public int nDiaCobranca { get; set; }
        public string sCnpjCpf { get; set; }
        public string sEndereco { get; set; }
        public string sCidade { get; set; }
        
        public string sEstado { get; set; }
        public string nContato { get; set; }
        
        public string sCep { get; set; }
        
        public bool sCorrente { get; set; }
        
        public int nQtdeParcelas { get; set; }
        
        public decimal nValorAproximado { get; set; }


        public TipoEmpresa tpEmpresa { get; set; }

        //public virtual ICollection<EnderecoEmpresa> EnderecoEmpresa { get; set; }

        //public virtual ICollection<TelefoneEmpresa> TelefoneEmpresa { get; set; }
    }
}
