using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd
{
    public static class StaticUser
    {
        private static int _UserID = 3;
        private static string _UserName = "Bro";
        private static int _TBLL = 2000;

        public static int UserID { get { return _UserID; } }
        public static string UserName { get { return _UserName; } }

        public static int TBLL { get { return _TBLL; } }





    }
}
