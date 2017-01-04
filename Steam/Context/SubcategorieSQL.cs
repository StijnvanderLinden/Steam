using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Steam.Context
{
    public class SubcategorieSQL : ISubcategorie
    {
        DatabaseConnection databaseConnection;
        public SubcategorieSQL()
        {
            databaseConnection = new DatabaseConnection();
        }
    }
}