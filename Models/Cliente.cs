using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_Excel.Models
{
    /// <summary>
    /// Representa a entidade de um Cliente no banco de dados.
    /// </summary>
    public record Cliente(
        int Id,
        string RazaoSocial,
        string Documento,
        string? Email,
        string? Telefone,
        string DataCadastro
    );
}
