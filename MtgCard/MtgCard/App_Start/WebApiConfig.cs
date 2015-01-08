using System.Net.Http.Headers;
using System.Web.Http;

namespace MtgCard.App_Start
{
	public class WebApiConfig
	{
		public static void RegisterRoutes(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}"
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
		}
	}
}