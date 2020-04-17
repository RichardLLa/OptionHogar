using Infrastructure.Aspect.DataAccess;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace OptionHogar.WebService.App_Data
{
    public static class Config
    {

        public static void Register()
        {
            try
            {

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional : true, reloadOnChange: true);
               var config = builder.Build();
                var appConnection = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("AppConnection").Value);
                if (appConnection != null)
                {
                    string appStringConnection = appConnection.ConnectionString;
                    DataAccessEnterprise.Initialize(appStringConnection);
                }
            }
            catch (Exception e)
            { string _mensaje = e.Message; }
        }

    }
}
