using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using System.Data;
using System.Data.SqlClient;

namespace Steam.Context
{
    public class BestellingSQL : IBestelling
    {
        public void AddBestelling(Bestelling bestelling)
        {
            var command = new SqlCommand("BestellingInvoeren");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@paraAccountID", bestelling.SpelerID));
            command.Parameters.Add(new SqlParameter("@paraBesteldatum", bestelling.Besteldatum));
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("GameID", typeof(int));
            int i = 1;
            foreach(Game game in bestelling.Games)
            {
                DataRow row = table.NewRow();
                row["ID"] = i;
                row["GameID"] = game.ID;
                table.Rows.Add(row);
                i++;
            }
            command.Parameters.Add(new SqlParameter("@paraDatatable", table));
            DatabaseConnection.DbConnectionInstance.ExecuteProcedure(command);
        }
    }
}