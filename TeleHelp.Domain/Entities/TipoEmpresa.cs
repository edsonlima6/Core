using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHelp.Domain.Entities
{
    public class TipoEmpresa
    {
        public TipoEmpresa()
        {
            Empresas = new List<Empresa>();
        }

        public int idTipoEmpresa { get; set; }
        public string sNome { get; set; }
        public string sDescricao { get; set; }

        public List<Empresa> Empresas { get; set; }
    }
}
