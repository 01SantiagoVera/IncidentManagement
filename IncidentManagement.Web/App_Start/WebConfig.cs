using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace IncidentManagement.Web
{
    public class WebConfig
    {
        public static void Register()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            DatabaseConfig.Initialize();
            AuthConfig.RegisterAuth();
        }
    }
} 