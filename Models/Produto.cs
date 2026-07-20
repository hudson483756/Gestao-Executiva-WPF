using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_Excel.Models
{
    /// <summary>
    /// Representa a entidade de um Produto ou Serviço no catálogo.
    /// </summary>
    public record Produto(
        int Id,
        string CodigoSku,
        string Nome,
        string Categoria,
        double PrecoUnitario,
        bool Ativo = true
    );
}
