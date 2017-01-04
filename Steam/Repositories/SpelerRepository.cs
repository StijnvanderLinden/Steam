using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;
using Steam.Repositories;

namespace Steam.Repositories
{
    public class SpelerRepository
    {
        ISpeler context;
        GameRepository gr = new GameRepository(new GameSQL());
        public SpelerRepository(ISpeler context)
        {
            this.context = context;
        }

        public void AddReview(Review review)
        {
            context.AddReview(review);
        }

        public List<Game> GetBibliotheek(Speler speler)
        {
            List<Game> games1 = context.GetBibliotheek(speler);
            if(games1 == null)
            {
                games1 = new List<Game>();
                return games1;
            }
            else
            {
                List<Game> games2 = new List<Game>();
                foreach (Game game1 in games1)
                {
                    Game game = gr.GetGameByID(game1.ID);
                    games2.Add(game);
                }
                return games2;
            }
        }
    }
}