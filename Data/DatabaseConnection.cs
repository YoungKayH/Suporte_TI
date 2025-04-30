using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Suporte_TI.Data
{
    internal class DatabaseConnection : IDisposable
    {
        private readonly string _connectionString;
        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
