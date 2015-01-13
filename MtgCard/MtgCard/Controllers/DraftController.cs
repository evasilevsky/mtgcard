using System.Web.Mvc;
using MtgCard.Services;

namespace MtgCard.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        public ActionResult Index()
        {
	        var packFactory = new PackFactory();
			var pack = packFactory.BuildRandomPackFromSet("KTK");
            return View(pack);
        }
    }
}