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
    public class BestellingController : Controller
    {
        // GET: Bestelling
        SpelerRepository sr = new SpelerRepository(new SpelerSQL());
        Speler speler;
        Games games = new Games();
        public ActionResult Index()
        {
            speler = (Speler)Session["Account"];
            return View(speler);
        }

        public ActionResult Delete(int id)
        {
            Game game = null;
            speler = (Speler)Session["Account"];
            foreach(Game game1 in speler.Winkelwagen.Games)
            {
                if(game1.ID == id)
                {
                    game = game1;
                    break;
                }
            }
            speler.Winkelwagen.Games.Remove(game);
            return View("Index");
        }

        public ActionResult Afronden()
        {
            speler = (Speler)Session["Account"];
            if(speler.Winkelwagen.Games.Count > 0)
            {
                Bestelling bestelling = new Bestelling(speler.ID, speler.Winkelwagen.Games, DateTime.Now);
                sr.AddBestelling(bestelling);
                foreach(Game game in bestelling.Games)
                {
                    speler.Games.Add(game);
                }
                speler.Winkelwagen.Games.Clear();
            }
            Response.Write("<script>alert('Bestelling succesvol afgerond.');</script>");
            return View("Index");
        }
    }
}