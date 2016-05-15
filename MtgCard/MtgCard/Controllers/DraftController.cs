using System.Web.Mvc;
using MtgCard.Services;

namespace MtgCard.Controllers
{
	public class DraftController : Controller
	{
		// GET: Draft
		public ActionResult Index()
		{
			var packFactory = new PackFactory(new CardAdapter());
			var pack = packFactory.BuildRandomPackFromSet("SOI");
			return View(pack);
		}
	}
}