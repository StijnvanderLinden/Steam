using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Steam.Context;
using Steam.Models;

namespace Steam.Context
{
    public class ReviewSQL : IReview
    {
        DatabaseConnection databaseConnection;
        public ReviewSQL()
        {
            databaseConnection = new DatabaseConnection();
        }
    }
}