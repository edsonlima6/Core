namespace MyBI.Domain1.Entities
{
    using System;
    using System.Collections.Generic;


    public partial class DetalheCliente
    {

        public int IdCliente { get; set; }

       
        public string UsrAltBas { get; set; }

     
        public DateTime? DtAltBas { get; set; }

        public string DiaPgtoMonit { get; set; }

        public double? VlrTelehelp { get; set; }

        public double? VlrCall { get; set; }

        public double? VlrDoctor { get; set; }

        public double? VlrHome { get; set; }

   
        public DateTime? DtUltReajuste { get; set; }

        public double? PercReajustes { get; set; }

        public string LibCobrMonit { get; set; }

 
        public DateTime? DtLibCobranca { get; set; }

      
        public DateTime? DtCad { get; set; }


        public string UsrCad { get; set; }


        public string CodStatus { get; set; }

       
        public string CodOrigem { get; set; }

     
        public string EnvioBanco { get; set; }

        
        public string CodIntClie { get; set; }
        
        public DateTime? DtFimMonit { get; set; }
        
        public DateTime? DtIniPgto { get; set; }
        
        public string MesAnoEnvBco { get; set; }
        
        public string ObsClie { get; set; }
        
        public string TipoPagto { get; set; }
        
        public string CartaoCred { get; set; }
        
        public string CodBancoCoobrigado { get; set; }
        
        public string CodAgenCoobrigado { get; set; }
        
        public string NumCtaCoobrigado { get; set; }
        
        public string TipoCartaoCred { get; set; }
        
        public string ValidCCred { get; set; }
        
        public string CODSEQ { get; set; }

        public double? PercRetIssMonitoria { get; set; }

        public double? PercRetIssAdesao { get; set; }

        public double? PercRetIssInstalacao { get; set; }

        public byte? IsInadimp { get; set; }
        
        public DateTime? DtRegInadimp { get; set; }

        public byte? IsPreCliente { get; set; }

        public byte? IsRetCSLL { get; set; }

        public byte? IsRetCOFINS { get; set; }

        public byte? IsRetPIS { get; set; }

        public byte? IsRetIR { get; set; }

        public byte? IsRetINSS { get; set; }

        public byte? IsNNC { get; set; }
        
        public string FisiJuriCobrigado { get; set; }
        
        public string RazaoSocialCobrigado { get; set; }
        
        public string InscrEstadCobrigado { get; set; }
        
        public string CGC_CPFCobrigado { get; set; }
        
        public decimal? IdGrupo { get; set; }
        
        public string Estabelecimento { get; set; }

        public double? VlrMonitoriaAnt { get; set; }

        public byte? IsNFe { get; set; }
        
        public string SenhaEquip { get; set; }
        
        public string CallHora { get; set; }
        
        public string CallAcao { get; set; }
        
        public string CallDiaria { get; set; }
        
        public string CallSemana { get; set; }
        
        public string CallDia { get; set; }
        
        public string PedOrig { get; set; }
        
        public string DiasTeste { get; set; }
        
        public string DtaUsrLib { get; set; }
        
        public string DtaUsrCan { get; set; }
        
        public string DtaUsrTes { get; set; }

        public DateTime? DtaConclui { get; set; }
        
        public string CadTeleWeb { get; set; }
        
        public DateTime? DtaTeleWeb { get; set; }

        public double? vlrAdicional { get; set; }

        public double? vlrID { get; set; }

        public double? VLRGPS { get; set; }

        public double? VLRVIDEO { get; set; }

        public double? VLRFUMACA { get; set; }

        public double? VLRGAS { get; set; }

        public double? VLRUSUARIOADICIONAL { get; set; }

        public double? VLRPAINELADICIONAL { get; set; }

        public double? VLRBOTAOFIXO { get; set; }
        
        public string TIPOPAGTONEGOCIACAO { get; set; }

        public double? vlrConserge { get; set; }

        public double? vlrLembreteMed { get; set; }

        public double? VlrConcierge { get; set; }
        
        public string FisiJuri { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
