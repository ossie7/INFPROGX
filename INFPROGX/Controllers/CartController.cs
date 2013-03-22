using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INFPROGX.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            ViewBag.Message = "De Winkelwagen";
            return View();
        }

    }
}
