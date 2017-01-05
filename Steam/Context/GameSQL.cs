using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Steam.Models;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Context
{
    public class GameSQL : IGame
    {
        public Game GetGameByID(int ID)
        {
            string query = "SELECT * FROM GAME WHERE ID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = DatabaseConnection.DbConnectionInstance.ExecuteQueryReader(command);
            Game game = new Game();
            while (reader.Read())
            {
                game.ID = reader.GetInt32(0);
                game.UitgeverID = reader.GetInt32(1);
                game.Naam = reader.GetString(2);
                game.Prijs = reader.GetDecimal(3);
                game.IMGUrl = reader.GetString(4);
                game.Sterren = reader.GetDecimal(5);
                game.Beschrijving = reader.GetString(6);
                return game;
            }
            return null;
        }
        public List<Game> GetAllGames()
        {
            string query = "SELECT * FROM GAME";
            var command = new SqlCommand(query);
            SqlDataReader reader = DatabaseConnection.DbConnectionInstance.ExecuteQueryReader(command);
            List<Game> games = new List<Game>();
            while (reader.Read())
            {
                Game game = new Game(reader.GetInt32(0), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(1), reader.GetDecimal(5), reader.GetString(6), reader.GetString(4));
                games.Add(game);
            }
            if(games.Count > 0)
            {
                return games;
            }
            else
            {
                return null;
            }
        }
        public void AddGame(Game game)
        {
            string query = "INSERT INTO GAME (UitgeverID, Naam, Prijs, IMGUrl, Sterren, Beschrijving) VALUES (@uitgeverID, @naam, @prijs, @IMGUrl, @Sterren, @Beschrijving)";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@uitgeverID", game.UitgeverID);
            command.Parameters.AddWithValue("@naam", game.Naam);
            command.Parameters.AddWithValue("@prijs", game.Prijs);
            command.Parameters.AddWithValue("@IMGUrl", game.IMGUrl);
            command.Parameters.AddWithValue("@Sterren", game.Sterren);
            command.Parameters.AddWithValue("@Beschrijving", game.Beschrijving);
            DatabaseConnection.DbConnectionInstance.ExecuteQuery(command);
        }

        public void DeleteGame(Game game)
        {
            string query = "DELETE FROM GAME WHERE ID = @gameID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@gameID", game.ID);
            DatabaseConnection.DbConnectionInstance.ExecuteQuery(command);
        }

        public void UpdateSterren(Game game)
        {
            string query = "UPDATE GAME SET STERREN = @sterren WHERE ID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@sterren", game.Sterren);
            command.Parameters.AddWithValue("@ID", game.ID);
            DatabaseConnection.DbConnectionInstance.ExecuteQuery(command);
        }

        public List<Review> GetReviewsByGameID(int ID)
        {
            string query = "SELECT * FROM REVIEW WHERE GameID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = DatabaseConnection.DbConnectionInstance.ExecuteQueryReader(command);
            List<Review> reviews = new List<Review>();
            while (reader.Read())
            {
                Review review = new Review(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                reviews.Add(review);
            }
            return reviews;
        }
    }
}