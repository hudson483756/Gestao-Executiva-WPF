using System.Windows.Controls;
using Projeto1_Excel.Repositories;
using Projeto1_Excel.Services;
using Projeto1_Excel.ViewModels;

namespace Projeto1_Excel.Views
{
    public partial class RelatoriosView : UserControl
    {
        public RelatoriosView()
        {
            InitializeComponent();

            var dbService = new DatabaseService();
            var vendaRepo = new VendaRepository(dbService);
            var excelService = new ExcelService();

            DataContext = new RelatoriosViewModel(vendaRepo, excelService);
        }
    }
}