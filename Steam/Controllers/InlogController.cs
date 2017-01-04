using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Steam.Models;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Controllers
{
    public class InlogController : Controller
    {
        BeheerderRepository br = new BeheerderRepository(new BeheerderSQL());
        SpelerRepository sr = new SpelerRepository(new SpelerSQL());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string inlognaam, string wachtwoord)
        {
            if(br.CheckGegevens(inlognaam, wachtwoord))
            {
                if(br.CheckOfSpelerBestaat(inlognaam, wachtwoord))
                {
                    Speler speler = new Speler(inlognaam, wachtwoord);
                    speler = br.GetSpeler(speler);
                    speler.Games = sr.GetBibliotheek(speler);
                    Session["Account"] = speler;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Beheerder beheerder = new Beheerder(inlognaam, wachtwoord);
                    beheerder = br.GetBeheerder(beheerder);
                    Session["Account"] = beheerder;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                Response.Write("<script>alert('Inlognaam of wachtwoord is onjuist.');</script>");
                return View("Index");
            }
        }

        public ActionResult Uitloggen()
        {
            Session["Account"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}