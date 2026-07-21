using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Projeto1_Excel.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Data Source=banco.db";

        public DatabaseService()
        {
            InicializarBanco();
        }

        public IDbConnection ObterConexao()
        {
            var conexao = new SqliteConnection(_connectionString);
            conexao.Open();
            return conexao;
        }

        private void InicializarBanco()
        {
            using var conexao = ObterConexao();

            const string sqlClientes = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RazaoSocial TEXT NOT NULL,
                    Documento TEXT NOT NULL,
                    Email TEXT,
                    Telefone TEXT,
                    DataCadastro TEXT
                );";

            const string sqlProdutos = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CodigoSku TEXT,
                    Nome TEXT NOT NULL,
                    Categoria TEXT,
                    PrecoUnitario REAL NOT NULL,
                    Ativo INTEGER DEFAULT 1
                );";

            const string sqlVendas = @"
                    CREATE TABLE IF NOT EXISTS Vendas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteNome TEXT NOT NULL,
                        ProdutoNome TEXT NOT NULL,
                        Quantidade INTEGER NOT NULL,
                        PrecoUnitario REAL NOT NULL,
                        Total REAL NOT NULL,
                        DataVenda TEXT NOT NULL
                );";

            

            conexao.Execute(sqlClientes);
            conexao.Execute(sqlProdutos);
            conexao.Execute(sqlVendas);
        }
    }
}