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
                if (sterren != null)
                {
                    Review review = new Review(game.ID, speler.ID, speler, game, titel, comment, (int)sterren);
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
            foreach (Game g in speler.Winkelwagen.Games)
            {
                if (g.ID == game.ID)
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
                    Games.games.Sort(new NaamComparer());
                    break;

                case "prijs":
                    Games.games.Sort(new PrijsComparer());
                    break;

                case "sterren":
                    Games.games.Sort(new SterrenComparer());
                    break;
            }
            return View("Index", Games);
        }

        public ActionResult DeleteReview(int id)
        {
            Game game = (Game)Session["Game"];
            Review review = null;
            foreach (Review r in game.Reviews)
            {
                if (r.ID == id)
                {
                    review = r;
                    break;
                }
            }
            if (review == null)
            {
                return HttpNotFound();
            }
            game.Reviews.Remove(review);
            gr.DeleteReview(review);
            return View("Details", game);
        }

        public ActionResult DeleteGame(int id)
        {
            Game game = null;
            foreach(Game g in Games.games)
            {
                if(g.ID == id)
                {
                    game = g;
                }
            }
            if(game == null)
            {
                return HttpNotFound();
            }
            Games.games.Remove(game);
            gr.DeleteGame(game);
            return View("Index", Games);
        }

        public ActionResult GameToevoegen()
        {
            return View("Toevoegen");
        }
    }
}