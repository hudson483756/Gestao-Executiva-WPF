using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_Excel.Models
{

    /// <summary>
    /// Representa o registro bruto de uma transação financeira de venda.
    /// </summary>
    public record Venda(
        int Id,
        int ClienteId,
        int ProdutoId,
        int Quantidade,
        double PrecoPraticado,
        string DataVenda
    );


}
