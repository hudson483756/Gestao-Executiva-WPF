using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_Excel.Models
{

    /// <summary>
    /// Objeto otimizado para exibição na tela e exportação direta para o relatório Excel.
    /// </summary>
    public record VendaRelatorioDTO(
        int VendaId,
        string NomeCliente,
        string CategoriaProduto,
        string NomeProduto,
        int Quantidade,
        double PrecoPraticado,
        double TotalVenda, // Calculado dinamicamente: Quantidade * PrecoPraticado
        string DataVenda
    );

}
