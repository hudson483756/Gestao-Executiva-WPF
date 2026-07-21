using System;

namespace Projeto1_Excel.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string DataCadastro { get; set; } = string.Empty;

        // Construtor sem parâmetros (Exigido pelo Dapper)
        public Cliente() { }

        // Construtor completo para facilitar o cadastro
        public Cliente(long id, string razaoSocial, string documento, string? email, string? telefone, string dataCadastro)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Documento = documento;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }
    }
}