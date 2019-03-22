using System;
using System.Collections.Generic;


namespace MyBI.Domain1.Entities
{
    public class Login
    {
        #region Atributos
        public int IdLogin { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string SenhaExtra { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        #endregion

        #region Construtores
        public Login()
        {
            this.Usuarios = new List<Usuario>();
        }
        #endregion

        #region Metodos
        #endregion

    }
}
