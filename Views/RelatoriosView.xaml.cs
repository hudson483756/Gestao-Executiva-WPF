using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto1_Excel.Models;
using Projeto1_Excel.Services;
using Projeto1_Excel.Services;
using System.Diagnostics;

namespace SeuProjeto.ViewModels;

public partial class RelatoriosViewModel : ObservableObject
{
    private readonly ExcelService _excelService = new();
    // Aqui você injetaria também seu repositório de vendas para puxar os dados do banco

    [RelayCommand]
    private void ExportarParaExcel()
    {
        // 1. Simulação dos dados que viriam do SQLite (Usando nosso DTO planejado)
        var dadosFakeDoBanco = new List<VendaRelatorioDTO>
        {
            new(1, "Empresa Alfa LTDA", "Softwares", "Licença Windows 11 PRO", 5, 150.00, 750.00, "2026-07-19"),
            new(2, "Logística Brasil S/A", "Consultorias", "Otimização de Processos", 1, 3500.00, 3500.00, "2026-07-19"),
            new(3, "Mário Autopeças", "Softwares", "Sistema ERP Corporativo", 2, 800.00, 1600.00, "2026-07-18")
        };

        // 2. Executa o motor de geração
        string caminhoDoArquivo = _excelService.GerarRelatorioFechamento(dadosFakeDoBanco);

        // 3. Feedback de Experiência do Usuário (UX): Abre o Excel gerado automaticamente
        var processInfo = new ProcessStartInfo
        {
            FileName = caminhoDoArquivo,
            UseShellExecute = true // Necessário no .NET Core / .NET 10 para abrir arquivos externos
        };
        Process.Start(processInfo);
    }
}