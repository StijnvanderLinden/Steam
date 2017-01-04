using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Steam.Controllers
{
    public class BibliotheekController : Controller
    {
        // GET: Bibliotheek
        public ActionResult Index()
        {
            return View();
        }
    }
}