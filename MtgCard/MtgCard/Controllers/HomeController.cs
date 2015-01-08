using System.Web.Mvc;

namespace MtgCard.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}