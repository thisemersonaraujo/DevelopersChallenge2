using BankingConciliation.Web.App_Start;
using BankingConciliation.Web.Mappings;
using System.Web.Mvc;
using System.Web.Routing;

namespace BankingConciliation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            SimpleInjectorConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
