using System.Windows.Controls;
using Projeto1_Excel.Repositories;
using Projeto1_Excel.Services;
using Projeto1_Excel.ViewModels;

namespace Projeto1_Excel.Views
{
    public partial class FinanceiroView : UserControl
    {
        private readonly FinanceiroViewModel _viewModel;

        public FinanceiroView()
        {
            InitializeComponent();

            var dbService = new DatabaseService();
            var clienteRepo = new ClienteRepository(dbService);
            var produtoRepo = new ProdutoRepository(dbService);
            var vendaRepo = new VendaRepository(dbService);

            _viewModel = new FinanceiroViewModel(clienteRepo, produtoRepo, vendaRepo);
            DataContext = _viewModel;

            Loaded += (s, e) => _viewModel.CarregarDados();
        }
    }
}