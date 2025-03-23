using System.Web.Security;
using System.Web.Mvc;
using System.Web;

namespace IncidentManagement.Web
{
    public class AuthConfig
    {
        public static void RegisterAuth()
        {
            FormsAuthentication.SetAuthCookie("admin", false);
        }
    }
} 