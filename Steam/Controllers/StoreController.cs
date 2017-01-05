using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Steam.Models;
using Steam.Repositories;
using Steam.Context;
using Steam.Comparers;

namespace Steam.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        SpelerRepository sr = new SpelerRepository(new SpelerSQL());
        BeheerderRepository br = new BeheerderRepository(new BeheerderSQL());
        GameRepository gr = new GameRepository(new GameSQL());
        Games Games = new Games();
        bool naam = false;
        bool prijs = false;
        bool sterren = false;
        public ActionResult Index()
        {
            return View(Games);
        }
        
        public ActionResult Details(int id)
        {
            Game game = null;
            foreach (Game g in Games.games)
            {
                if (g.ID == id)
                {
                    game = g;
                    break;
                }
            }

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult Review(string titel, string comment, int? sterren)
        {
            Speler speler = (Speler)Session["Account"];
            Game game = (Game)Session["Game"];
            if (titel != null)
            {
                if(sterren != null)
                {
                    Review review = new Review(game.ID, speler.ID, titel, comment, (int)sterren);
                    try
                    {
                        sr.AddReview(review);
                        game.UpdateSterren(review);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Vul het aantal sterren in.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Vul een titel in.');</script>");
            }
            return View("Details", game);
            
        }

        public ActionResult Toevoegen(int id)
        {
            Game game = null;
            Speler speler = (Speler)Session["Account"];
            foreach (Game g in Games.games)
            {
                if (g.ID == id)
                {
                    game = g;
                    break;
                }
            }

            if (game == null)
            {
                return HttpNotFound();
            }
            bool exists = false;
            foreach(Game g in speler.Winkelwagen.Games)
            {
                if(g.ID == game.ID)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                speler.Winkelwagen.Games.Add(game);
            }
            else
            {
                Response.Write("<script>alert('Deze game staat al in je bestelling.');</script>");
            }
            return View("Details", game);
        }

        public ActionResult Compare(string comparer)
        {
            switch (comparer)
            {
                case "naam":
                    if (!naam)
                    {
                        Games.games.Sort(new NaamComparer());
                    }
                    else
                    {
                        Games.games.Sort(new NaamDescComparer());
                    }
                    break;

                case "prijs":
                    if (!prijs)
                    {
                        Games.games.Sort(new PrijsComparer());
                    }
                    else
                    {
                        Games.games.Sort(new PrijsDescComparer());
                    }
                    break;

                case "sterren":
                    if (!sterren)
                    {
                        Games.games.Sort(new SterrenComparer());
                    }
                    else
                    {
                        Games.games.Sort(new SterrenDescComparer());
                    }
                    break;
            }
            return View("");
        }
    }
}