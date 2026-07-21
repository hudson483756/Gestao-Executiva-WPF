using System;

namespace Projeto1_Excel.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string CodigoSku { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public double PrecoUnitario { get; set; }
        public bool Ativo { get; set; } = true;

        // Construtor sem parâmetros (Obrigatório para o Dapper materializar o objeto)
        public Produto() { }

        // Construtor opcional para facilitar a criação manual
        public Produto(long id, string codigoSku, string nome, string categoria, double precoUnitario, bool ativo = true)
        {
            Id = id;
            CodigoSku = codigoSku;
            Nome = nome;
            Categoria = categoria;
            PrecoUnitario = precoUnitario;
            Ativo = ativo;
        }
    }
}