using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto1_Excel.Models;
using Projeto1_Excel.Repositories;

namespace Projeto1_Excel.ViewModels
{
    public partial class FinanceiroViewModel : ObservableObject
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ProdutoRepository _produtoRepository;
        private readonly VendaRepository _vendaRepository;

        // Listas para a tela
        public ObservableCollection<Cliente> Clientes { get; } = new();
        public ObservableCollection<Produto> Produtos { get; } = new();
        public ObservableCollection<Venda> Vendas { get; } = new();

        // Campos de Seleção
        [ObservableProperty] private Cliente? _clienteSelecionado;
        [ObservableProperty] private Produto? _produtoSelecionado;
        [ObservableProperty] private int _quantidade = 1;

        public FinanceiroViewModel(ClienteRepository clienteRepository, ProdutoRepository produtoRepository, VendaRepository vendaRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;

            CarregarDados();
        }

        public void CarregarDados()
        {
            Clientes.Clear();
            foreach (var cliente in _clienteRepository.ListarTodos())
                Clientes.Add(cliente);

            Produtos.Clear();
            foreach (var produto in _produtoRepository.ListarTodos())
                Produtos.Add(produto);

            AtualizarListaVendas();
        }

        [RelayCommand]
        private void LancarVenda()
        {
            // Valida se cliente e produto foram selecionados e se a quantidade é válida
            if (ClienteSelecionado == null || ProdutoSelecionado == null || Quantidade <= 0)
                return;

            double valorTotal = ProdutoSelecionado.PrecoUnitario * Quantidade;

            var novaVenda = new Venda
            {
                ClienteNome = ClienteSelecionado.RazaoSocial,
                ProdutoNome = ProdutoSelecionado.Nome,
                Quantidade = Quantidade,
                PrecoUnitario = ProdutoSelecionado.PrecoUnitario,
                Total = valorTotal,
                DataVenda = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            };

            // Salva no banco de dados SQLite
            _vendaRepository.Inserir(novaVenda);

            // Reseta os campos e atualiza a grid
            Quantidade = 1;
            ClienteSelecionado = null;
            ProdutoSelecionado = null;

            AtualizarListaVendas();
        }

        private void AtualizarListaVendas()
        {
            Vendas.Clear();
            foreach (var venda in _vendaRepository.ListarTodas())
                Vendas.Add(venda);
        }
    }
}