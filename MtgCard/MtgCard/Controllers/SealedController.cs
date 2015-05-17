using MtgCard.Domain;
using MtgCard.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MtgCard.Controllers
{
    public class SealedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}