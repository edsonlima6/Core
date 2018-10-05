using System;
using System.Collections.Generic;
using TeleHelp.Domain.Entities.Cadastro;

namespace TeleHelp.Domain.Entities
{
    public class AliquotaICM
    {
        #region Atributos
        public int IdAliquotaICMS { get; set; }
        public int IdEstado { get; set; }
        public decimal Percentual { get; set; }
        public virtual Estado Estado { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
        
    }
}
