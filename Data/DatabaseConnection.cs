using System;
using Npgsql;
using Suporte_TI.Const;

namespace Suporte_TI.Data
{
    internal class DatabaseConnection : IDisposable
    {
        private readonly NpgsqlConnection _connection;

        public DatabaseConnection()
        {
            try
            {
                _connection = new NpgsqlConnection(Constants.Database.ConnectionUrl);
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados PostgreSQL: " + ex.Message);
            }
        }

        public NpgsqlConnection GetConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
