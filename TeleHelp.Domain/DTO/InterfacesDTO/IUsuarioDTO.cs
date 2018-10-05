using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Enums.Comuns;

namespace TeleHelp.Domain.DTO.InterfacesDTO
{
    public interface IUsuarioDTO
    {
        SistemaEnuns.Acao acao { get; set; }
        int IdUsuario { get; set; }

        string Nome { get; set; }

        DateTime DataCadastro { get; set; }

        byte[] Foto { get; set; }

        int? Matricula { get; set; }

        int? Turno { get; set; }

        TimeSpan? HorarioEntrada { get; set; }

        TimeSpan? HorarioSaida { get; set; }

        int IdTipoUsuario { get; set; }

        int IdTipoAtendimento { get; set; }

        string Email { get; set; }

        bool Ativo { get; set; }

        int IdCargo { get; set; }

        int IdDepartamento { get; set; }

        string Login { get; set; }

        byte[] Senha { get; set; }

        byte[] SenhaExtra { get; set; }

        DateTime? DataAlteracao { get; set; }

        Departamento Departamento { get; set; }
        Cargo Cargo { get; set; }
        Usuario Usuario { get; set; }
        List<GrupoUsuario> gruposUsuario { get; set; }
        GrupoUsuario grupoUsuario { get; set; }
        RepresentanteUsuario representanteUsuario { get; set; }
        Grupo grupo { get; set; }
       

        bool ValidaCadastroUsuario();
        void NovoObjeto();
    }
}
