using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steam.Models;

namespace Steam.Context
{
    public interface IGame
    {
        void AddGame(Game game);
        void DeleteGame(Game game);
        void UpdateSterren(Game game);
        Game GetGameByID(int ID);
        List<Game> GetAllGames();
        List<Review> GetReviewsByGame(Game game);
    }
}
