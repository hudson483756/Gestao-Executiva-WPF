using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto1_Excel.Repositories;
using Projeto1_Excel.Services;
using System.Diagnostics;
using System.Linq;

namespace Projeto1_Excel.ViewModels
{
    public partial class RelatoriosViewModel : ObservableObject
    {
        private readonly ExcelService _excelService;
        private readonly VendaRepository _vendaRepository;

        public RelatoriosViewModel(VendaRepository vendaRepository, ExcelService excelService)
        {
            _vendaRepository = vendaRepository;
            _excelService = excelService;
        }

        [RelayCommand]
        private void ExportarParaExcel()
        {
            // 1. Busca as vendas reais já cadastradas no banco SQLite
            var vendasDoBanco = _vendaRepository.ListarTodas().ToList();

            // Validação simples: se não houver registros, não tenta gerar o arquivo
            if (!vendasDoBanco.Any())
                return;

            // 2. Executa a geração da planilha formatada
            string caminhoDoArquivo = _excelService.GerarRelatorioFechamento(vendasDoBanco);

            // 3. Abre o arquivo do Excel automaticamente no sistema operacional
            var processInfo = new ProcessStartInfo
            {
                FileName = caminhoDoArquivo,
                UseShellExecute = true
            };
            Process.Start(processInfo);
        }
    }
}