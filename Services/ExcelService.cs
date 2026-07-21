using ClosedXML.Excel;
using Projeto1_Excel.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto1_Excel.Services;

public class ExcelService
{
    public string GerarRelatorioFechamento(IEnumerable<Venda> vendas)
    {
        // Define o caminho no diretório Meus Documentos para salvar o relatório
        string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string caminhoArquivo = Path.Combine(pastaDocumentos, $"Fechamento_Executivo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

        using var workbook = new XLWorkbook();

        // 1. Configuração da Aba Principal
        var worksheet = workbook.Worksheets.Add("Fechamento de Vendas");
        worksheet.ShowGridLines = true;

        // 2. Estilização do Cabeçalho
        string[] cabecalhos = ["ID Venda", "Cliente", "Produto", "Qtd", "Preço Praticado", "Total Venda", "Data"];

        for (int i = 0; i < cabecalhos.Length; i++)
        {
            var celula = worksheet.Cell(1, i + 1);
            celula.Value = cabecalhos[i];
            celula.Style.Font.Bold = true;
            celula.Style.Font.FontColor = XLColor.White;
            celula.Style.Fill.BackgroundColor = XLColor.FromHtml("#1B365D"); // Navy Blue Corporativo
            celula.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        // 3. Alimentando os Dados e aplicando Efeito Zebrado
        int linhaAtual = 2;
        foreach (var v in vendas)
        {
            worksheet.Cell(linhaAtual, 1).Value = v.Id;
            worksheet.Cell(linhaAtual, 2).Value = v.ClienteNome;
            worksheet.Cell(linhaAtual, 3).Value = v.ProdutoNome;
            worksheet.Cell(linhaAtual, 4).Value = v.Quantidade;
            worksheet.Cell(linhaAtual, 5).Value = v.PrecoUnitario;
            worksheet.Cell(linhaAtual, 6).Value = v.Total;
            worksheet.Cell(linhaAtual, 7).Value = v.DataVenda;

            // Formatação Monetária nas colunas de preço e total
            worksheet.Cell(linhaAtual, 5).Style.NumberFormat.Format = "R$ #,##0.00";
            worksheet.Cell(linhaAtual, 6).Style.NumberFormat.Format = "R$ #,##0.00";

            // Estilo Zebrado (Linhas pares ganham fundo cinza bem claro)
            if (linhaAtual % 2 == 0)
            {
                for (int col = 1; col <= cabecalhos.Length; col++)
                {
                    worksheet.Cell(linhaAtual, col).Style.Fill.BackgroundColor = XLColor.FromHtml("#F2F4F7");
                }
            }
            linhaAtual++;
        }

        // 4. Injeção de Fórmulas Totais na Base do Relatório
        int linhaTotal = linhaAtual + 1;
        worksheet.Cell(linhaTotal, 5).Value = "Faturamento Total:";
        worksheet.Cell(linhaTotal, 5).Style.Font.Bold = true;

        // Fórmula nativa do Excel: SUM(F2:F[N])
        var celulaFormula = worksheet.Cell(linhaTotal, 6);
        celulaFormula.FormulaA1 = $"SUM(F2:F{linhaAtual - 1})";
        celulaFormula.Style.Font.Bold = true;
        celulaFormula.Style.NumberFormat.Format = "R$ #,##0.00";
        celulaFormula.Style.Fill.BackgroundColor = XLColor.FromHtml("#E2E8F0");

        // 5. Ajuste Automático do Tamanho das Colunas
        worksheet.Columns().AdjustToContents();

        // Salva o arquivo no disco
        workbook.SaveAs(caminhoArquivo);
        return caminhoArquivo;
    }
}