using System.Collections.Generic;
using Dapper;
using Projeto1_Excel.Models;
using Projeto1_Excel.Services;

namespace Projeto1_Excel.Repositories
{
    public class ClienteRepository
    {
        private readonly DatabaseService _dbService;

        public ClienteRepository(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public void Inserir(Cliente cliente)
        {
            using var conexao = _dbService.ObterConexao();
            const string sql = @"INSERT INTO Clientes (RazaoSocial, Documento, Email, Telefone, DataCadastro) 
                             VALUES (@RazaoSocial, @Documento, @Email, @Telefone, @DataCadastro);";
            conexao.Execute(sql, cliente);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            using var conexao = _dbService.ObterConexao();
            return conexao.Query<Cliente>("SELECT * FROM Clientes ORDER BY RazaoSocial;");
        }
    }
}