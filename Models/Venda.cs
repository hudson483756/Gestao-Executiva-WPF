using System;

namespace Projeto1_Excel.Models
{
    public class Venda
    {
        public long Id { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string ProdutoNome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Total { get; set; }
        public string DataVenda { get; set; } = string.Empty;

        public Venda() { }

        public Venda(long id, string clienteNome, string produtoNome, int quantidade, double precoUnitario, double total, string dataVenda)
        {
            Id = id;
            ClienteNome = clienteNome;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Total = total;
            DataVenda = dataVenda;
        }
    }
}