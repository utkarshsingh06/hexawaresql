using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Utility
{
    internal class DbConutil
    {
        private static IConfiguration _iconfiguration;

        static DbConutil()
        {
            GetAppsetttingsfile();
        }

        private static void GetAppsetttingsfile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionStrings");
        }
    }
}
