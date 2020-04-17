using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Util
{
    public static class ConnectionFactory
    {
        private const string cadenaconexion = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OptionHogarSecurity;Data Source=localhost;";

        //private static string cadenaconexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        //private const string cadenaconexion = "Persist Security Info=False;User ID=sysBank;Password=Pa$$w0rd2016;Data Source=190.223.57.237;";
        public static SqlConnection conexion()
        {
            try
            {
                return new SqlConnection(cadenaconexion);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
