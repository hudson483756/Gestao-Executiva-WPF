using System.Collections.Generic;
using Dapper;
using Projeto1_Excel.Models;
using Projeto1_Excel.Services;

namespace Projeto1_Excel.Repositories
{
    public class VendaRepository
    {
        private readonly DatabaseService _dbService;

        public VendaRepository(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public void Inserir(Venda venda)
        {
            using var conexao = _dbService.ObterConexao();
            const string sql = @"INSERT INTO Vendas (ClienteNome, ProdutoNome, Quantidade, PrecoUnitario, Total, DataVenda) 
                             VALUES (@ClienteNome, @ProdutoNome, @Quantidade, @PrecoUnitario, @Total, @DataVenda);";
            conexao.Execute(sql, venda);
        }

        public IEnumerable<Venda> ListarTodas()
        {
            using var conexao = _dbService.ObterConexao();
            return conexao.Query<Venda>("SELECT * FROM Vendas ORDER BY Id DESC;");
        }
    }
}