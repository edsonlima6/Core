using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Enums.Comuns;

namespace MyBI.Domain1.DTO.InterfacesDTO
{
    public interface IGrupoDTO
    {
        SistemaEnuns.Acao Acao { get; set; }
        int IdGrupo { get; set; }

        string Nome { get; set; }

        string Descricao { get; set; }

        bool Ativo { get; set; }

        Grupo Grupo { get; set; }
        
        IList<Grupo> Grupos { get; set; }

        IList<Tela> Telas { get; set; }

        IList<PermissaoTela> GrupoTelas { get; set; }
        PermissaoTela PermissaoTela { get;}
        void NovosObjetos();


    }
}
