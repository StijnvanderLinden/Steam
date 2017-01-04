using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Steam.Models;

namespace Steam.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Games games = new Games();
        public ActionResult Index()
        {
            return View(games);
        }
        
    }
}