using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ComputerRentalClientApp.Services
{
    public static class ServiceConstants
    {
        private static string getValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string ComputerServiceUrl
        {

            get { return getValue("ComputerServiceUrl"); }
        }
    }
}
