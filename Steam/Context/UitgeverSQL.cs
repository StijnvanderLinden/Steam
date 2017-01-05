using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Steam.Models;

namespace Steam.Context
{
    public class UitgeverSQL : IUitgever
    {
        public Uitgever GetUitgeverByID(int ID)
        {
            string query = "SELECT * FROM UITGEVER WHERE ID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = DatabaseConnection.DbConnectionInstance.ExecuteQueryReader(command);
            Uitgever uitgever = new Uitgever(ID);
            while (reader.Read())
            {
                uitgever.ID = reader.GetInt32(0);
                uitgever.Naam = reader.GetString(1);
                uitgever.Emailadres = reader.GetString(2);
                return uitgever;
            }
            return null;
        }
    }
}