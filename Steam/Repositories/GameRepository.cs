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
            List<Game> games = context.GetAllGames();
            foreach(Game game in games)
            {
                GetReviewsByGame(game);
            }
            return games;
        }
        public List<Review> GetReviewsByGame(Game game)
        {
            List<Review> reviews = context.GetReviewsByGame(game);
            game.Reviews.Clear();
            foreach(Review review in reviews)
            {
                review.Game = game;
                review.Speler = br.GetSpelerByID(review.SpelerID);
                game.Reviews.Add(review);
            }
            return reviews;
        }

        public void UpdateSterren(Game game)
        {
            context.UpdateSterren(game);
        }

        public void DeleteReview(Review review)
        {
            context.DeleteReview(review);
        }
    }
}