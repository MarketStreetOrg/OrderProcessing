using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OrderProcessingCore.Utilities
{
    public static class PropertyConfigurations
    {
        static IConfiguration Configuration;

        private static string iniFile = Configuration.GetSection("StaticFiles").GetValue<string>("IniPath");

        static IniFile ini = new IniFile(iniFile);
            
        public static void Write(string key, string value, string section = null)
        {
            ini.Write(key, value, section);
        }

        public static string Read(string key,string section = null)
        {
            return ini.Read(key, section);
        }

        
    }
}