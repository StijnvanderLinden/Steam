using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;
using Steam.Repositories;

namespace Steam.Repositories
{
    public class GameRepository
    {
        BeheerderRepository br = new BeheerderRepository(new BeheerderSQL());
        IGame context;
        public GameRepository(IGame context)
        {
            this.context = context;
        }
        public Game GetGameByID(int ID)
        {
            return context.GetGameByID(ID);
        }

        public void AddGame(Game game)
        {
            context.AddGame(game);
        }

        public void DeleteGame(Game game)
        {
            context.DeleteGame(game);
        }

        public List<Game> GetAllGames()
        {
            return context.GetAllGames();
        }
        public List<Review> GetReviewsByGameID(int ID)
        {
            List<Review> reviews = context.GetReviewsByGameID(ID);
            foreach(Review review in reviews)
            {
                review.Game = context.GetGameByID(review.GameID);
                review.Speler = br.GetSpelerByID(review.SpelerID);
            }
            return reviews;
        }

        public void UpdateSterren(Game game)
        {
            context.UpdateSterren(game);
        }
    }
}