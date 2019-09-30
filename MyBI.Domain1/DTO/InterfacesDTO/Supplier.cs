using System;

namespace MyBI.Domain1.DTO.InterfacesDTO
{
    public class Supplier
    {
        public int idRazaoSocial { get; set; }

        //public int idTipoEmpresa { get; set; }
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

    }
}