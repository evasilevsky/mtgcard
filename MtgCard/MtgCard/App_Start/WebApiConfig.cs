using System.Net.Http.Headers;
using System.Web.Http;

namespace MtgCard.App_Start
{
	public class WebApiConfig
	{
		public static void RegisterRoutes(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "GetRandomPack",
				routeTemplate: "api/draft/getRandomPack",
				defaults: new { controller = "DraftApi", action = "GetRandomPack", id = RouteParameter.Optional }
			);


			config.Routes.MapHttpRoute(
				name: "GetDraft",
				routeTemplate: "api/draft/getdraft",
				defaults: new { controller = "DraftApi", action = "GetDraft", id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
		}
	}
}