using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Classes
{
    public class Settings
    {
        private static Settings settings;

        public string authToken { get; set; }

        private Settings()
        {

        }

        public static Settings getInstance()
        {
           if(settings == null)
               settings = new Settings();
            return settings;
        }
    }
}
