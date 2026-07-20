using System.Collections.Generic;
using Dapper;
using Projeto1_Excel.Models;
using Projeto1_Excel.Services;

namespace Projeto1_Excel.Repositories
{
    public class ProdutoRepository
    {
        private readonly DatabaseService _dbService;

        public ProdutoRepository(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public void Inserir(Produto produto)
        {
            using var conexao = _dbService.ObterConexao();
            const string sql = @"INSERT INTO Produtos (CodigoSku, Nome, Categoria, PrecoUnitario, Ativo) 
                             VALUES (@CodigoSku, @Nome, @Categoria, @PrecoUnitario, @Ativo);";
            conexao.Execute(sql, produto);
        }

        public IEnumerable<Produto> ListarTodos()
        {
            using var conexao = _dbService.ObterConexao();
            return conexao.Query<Produto>("SELECT * FROM Produtos WHERE Ativo = 1 ORDER BY Nome;");
        }
    }
}