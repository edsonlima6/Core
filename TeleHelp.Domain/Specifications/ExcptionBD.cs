using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHelp.Domain.Specifications
{
    public class ExcptionBD
    {
        public ExcptionBD()
        {

        }


        public static string ErrosDataBase(DbUpdateException error)
        {
            string erroRetorno = null;
            int num = (((SqlException)error.InnerException.InnerException).Number);
            switch(num)
            {
                case 2601: erroRetorno = "O VALOR INFORMADO JÁ EXISTE NA BASE DE DADOS \n" + ((SqlException)error.InnerException.InnerException).Message;
                    break;

            }

            return erroRetorno;
        }


    }
}
