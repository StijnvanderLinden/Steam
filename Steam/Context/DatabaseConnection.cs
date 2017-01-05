using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Steam.Context
{
    public class DatabaseConnection
    {
        private const string conString = @"Data Source=STIJN\SQLEXPRESS;Initial Catalog = Steam; Integrated Security = True";
        private static DatabaseConnection _dbConnectionInstance;
        //Singleton
        public static DatabaseConnection DbConnectionInstance
        {
            get
            {
                if (_dbConnectionInstance == null)
                {
                    _dbConnectionInstance = new DatabaseConnection();
                }
                return _dbConnectionInstance;
            }
        }

        private SqlConnection GetConnection()
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                connection = new SqlConnection(conString);
                connection.Open();
            }

            if (lastReader != null && !lastReader.IsClosed)
            {
                lastReader.Close();
            }

            return connection;
        }

        public void ExecuteQuery(SqlCommand command)
        {
            command.Connection = GetConnection();
            command.ExecuteNonQuery();
        }

        private SqlConnection connection;
        private SqlDataReader lastReader;
        public SqlDataReader ExecuteQueryReader(SqlCommand command)
        {
            command.Connection = GetConnection();
            var reader = command.ExecuteReader();
            lastReader = reader;
            return reader;
        }

        public void ExecuteProcedure(SqlCommand command)
        {
            command.Connection = GetConnection();
            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteProcedureReader(string Procedure)
        {
            var connection = GetConnection();

            using (var conn = GetConnection())
            {
                using (var command = new SqlCommand(Procedure, conn) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    var reader = command.ExecuteReader();
                    lastReader = reader;
                    return reader;
                }
            }
        }
    }
}