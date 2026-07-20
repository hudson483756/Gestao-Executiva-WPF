using System.Data;
using Microsoft.Data.Sqlite;

namespace Projeto1_Excel.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Data Source=banco.db";

        public IDbConnection ObterConexao()
        {
            var conexao = new SqliteConnection(_connectionString);
            conexao.Open();
            return conexao;
        }
    }
}