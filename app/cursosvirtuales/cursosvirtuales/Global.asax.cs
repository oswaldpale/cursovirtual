using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace cursosvirtuales
{
    public class Global : System.Web.HttpApplication
    {
        internal static string path;
        public static string key = "cursoonline";
        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}