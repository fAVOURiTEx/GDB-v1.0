using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCT
{
    class Clases
    {

        public static class UserInformation
        {
            public static string UserServer = ConfigurationManager.AppSettings.Get("localsql");

            public static Int32 UserID;
            public static String Nickname;

        }
    }
}
