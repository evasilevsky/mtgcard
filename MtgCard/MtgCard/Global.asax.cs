using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MtgCard.App_Start;

namespace MtgCard
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			WebApiConfig.RegisterRoutes(GlobalConfiguration.Configuration);
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
