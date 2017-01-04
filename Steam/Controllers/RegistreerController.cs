using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Steam.Repositories;
using Steam.Context;
using Steam.Models;

namespace Steam.Controllers
{
    public class RegistreerController : Controller
    {
        BeheerderRepository br = new BeheerderRepository(new BeheerderSQL());
        // GET: Registreer
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Registreer(string nickname, string inlognaam, string wachtwoord, string herhaal_wachtwoord, string woonplaats, string emailadres)
        {
            if (!br.CheckNickname(nickname))
            {
                if (!br.CheckInlognaam(inlognaam))
                {
                    if(wachtwoord == herhaal_wachtwoord)
                    {
                        Speler speler = new Speler(nickname, inlognaam, wachtwoord, woonplaats, emailadres, new List<Game>(), new Winkelwagen());
                        br.AddSpeler(speler);
                        return RedirectToAction("Index", "Inlog");
                    }
                    else
                    {
                        Response.Write("<script>alert('2e wachtwoord is niet hetzelfde.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Inlognaam bestaat al.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Nickname bestaat al.');</script>");
            }
            return null;
        }
    }
}