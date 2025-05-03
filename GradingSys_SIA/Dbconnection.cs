using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GradingSys_SIA
{

    public class DbConnection
    {
        private readonly string connectionString;
        private MySqlConnection connection;
        private bool _disposed = false;

        public DbConnection(string databaseName = "cis_db")
        {
            connectionString = $"server=localhost;user id=root;password=;database={databaseName};";
            connection = new MySqlConnection(connectionString);
        }
        public string ConnectionString
        {
            get { return connectionString; }
        }

        public MySqlConnection GetConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Failed to open database connection: {ex.Message}", ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Failed to close database connection: {ex.Message}", ex);
            }
        }
        public void ChangeDatabase(string databaseName)
        {
            try
            {
                connection.ChangeDatabase(databaseName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change database: {ex.Message}", ex);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DbConnection()
        {
            Dispose(false);
        }
    }
}
