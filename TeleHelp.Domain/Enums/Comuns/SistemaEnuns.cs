using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHelp.Domain.Enums.Comuns
{
    public static class SistemaEnuns
    {

        public enum MenuPrincipal : int
        {
            DASHBOARD = 0,
            CLIENTE = 1,
            FINANCEIRO = 2,
            COMERCIAL = 3,
            ADMINISTRATIVO = 4

        }

        public enum Acao
        {
            INCLUIR,
            ALTERAR,
            EXCLUIR
        }
        public enum MenuBaseGravar
        {
            INCLUIR,
            ALTERAR,
            EXCLUIR,
            GRAVAR,
            CANCELAR,
            DEFAULT
        }

        public enum TipoUsuario : int
        {
            ATENDENTE = 1,
            VENDEDOR = 2,
            USUARIO = 3
        }

        public enum TipoAtendimento : int
        {
            FILATELEVENDAS = 1,
            FILAINDICACAO = 2,
            FILAPENDENCIA = 3,
            NAOATENDE = 4
        }

    }

}
