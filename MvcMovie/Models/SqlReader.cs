using System.Data.SqlClient;
using Dapper;

namespace MvcMovie.Models
{
    public class SqlReader
    {
        private string _connectionString { get; set; }

        public SqlReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Person>> GetUsers()
        {
            List<Person> people = new();
            var query = $"select * from Users";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                people = connection.Query<Person>(query).ToList();
            }

            return people;
        }
    }
}
