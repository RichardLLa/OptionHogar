using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Aspect.DataAccess;

namespace Infrastructure.DataAccess.Util
{
    public static class GetDateTimeServer
    {
        public static DateTime? ExtractDT()
        {
            DateTime? FechaHora = null;
            try
            {
                SqlCommand _command = DataAccessEnterprise.AsignProcedure("System_DateTimeServer");
                _command.Connection = DataAccessEnterprise.BeginConnection();
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        FechaHora = (DateTime?)reader["HourDate"];
                    }
                    //DataAccessEnterprise.EndConnection();
                    _command.Connection.Close();
                }
                return FechaHora;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
