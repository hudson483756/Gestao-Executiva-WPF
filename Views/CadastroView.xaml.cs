using System.Windows.Controls;
using Projeto1_Excel.Repositories;
using Projeto1_Excel.Services;
using Projeto1_Excel.ViewModels;

namespace Projeto1_Excel.Views
{
    public partial class CadastroView : UserControl
    {
        public CadastroView()
        {
            InitializeComponent();

            var dbService = new DatabaseService();
            var clienteRepo = new ClienteRepository(dbService);
            var produtoRepo = new ProdutoRepository(dbService);

            DataContext = new CadastroViewModel(clienteRepo, produtoRepo);
        }
    }
}