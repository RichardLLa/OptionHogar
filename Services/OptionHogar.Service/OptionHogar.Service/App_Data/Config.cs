using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Infrastructure.Aspect.DataAccess;

namespace OptionHogar.Service
{
    public static class Config
    {
        public static void Register()
        {
            try
            {

                var StringConnectionPath = HttpContext.Current.Server.MapPath("~/Web.config");
                var StringConnectionMap = new ExeConfigurationFileMap() { ExeConfigFilename = StringConnectionPath };
                var config = ConfigurationManager.OpenMappedExeConfiguration(StringConnectionMap, ConfigurationUserLevel.None);
                var appConnection = config.ConnectionStrings.ConnectionStrings["AppConnection"];
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