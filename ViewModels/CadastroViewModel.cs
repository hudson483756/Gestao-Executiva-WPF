using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto1_Excel.Models;
using Projeto1_Excel.Repositories;

namespace Projeto1_Excel.ViewModels
{
    public partial class CadastroViewModel : ObservableObject
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ProdutoRepository _produtoRepository;

        // ==========================================
        // CLIENTES
        // ==========================================
        [ObservableProperty] private string _razaoSocial = string.Empty;
        [ObservableProperty] private string _documento = string.Empty;
        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _telefone = string.Empty;

        public ObservableCollection<Cliente> Clientes { get; } = new();

        // ==========================================
        // PRODUTOS
        // ==========================================
        [ObservableProperty] private string _codigoSku = string.Empty;
        [ObservableProperty] private string _nomeProduto = string.Empty;
        [ObservableProperty] private string _categoria = string.Empty;
        [ObservableProperty] private double _precoUnitario;

        public ObservableCollection<Produto> Produtos { get; } = new();

        public CadastroViewModel(ClienteRepository clienteRepository, ProdutoRepository produtoRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;

            AtualizarListaClientes();
            AtualizarListaProdutos();
        }

        // --- MÉTODOS CLIENTE ---
        [RelayCommand]
        private void SalvarCliente()
        {
            if (string.IsNullOrWhiteSpace(RazaoSocial) || string.IsNullOrWhiteSpace(Documento))
                return;

            var novoCliente = new Cliente
            {
                RazaoSocial = RazaoSocial,
                Documento = Documento,
                Email = string.IsNullOrWhiteSpace(Email) ? null : Email,
                Telefone = string.IsNullOrWhiteSpace(Telefone) ? null : Telefone,
                DataCadastro = DateTime.Now.ToString("yyyy-MM-dd")
            };

            _clienteRepository.Inserir(novoCliente);

            LimparCamposCliente();
            AtualizarListaClientes();
        }

        private void AtualizarListaClientes()
        {
            Clientes.Clear();
            foreach (var cliente in _clienteRepository.ListarTodos())
            {
                Clientes.Add(cliente);
            }
        }

        private void LimparCamposCliente()
        {
            RazaoSocial = string.Empty;
            Documento = string.Empty;
            Email = string.Empty;
            Telefone = string.Empty;
        }

        // --- MÉTODOS PRODUTO ---
        [RelayCommand]
        private void SalvarProduto()
        {
            if (string.IsNullOrWhiteSpace(NomeProduto) || PrecoUnitario <= 0)
                return;

            var novoProduto = new Produto
            {
                CodigoSku = CodigoSku,
                Nome = NomeProduto,
                Categoria = Categoria,
                PrecoUnitario = PrecoUnitario,
                Ativo = true
            };

            _produtoRepository.Inserir(novoProduto);

            LimparCamposProduto();
            AtualizarListaProdutos();
        }

        private void AtualizarListaProdutos()
        {
            Produtos.Clear();
            foreach (var produto in _produtoRepository.ListarTodos())
            {
                Produtos.Add(produto);
            }
        }

        private void LimparCamposProduto()
        {
            CodigoSku = string.Empty;
            NomeProduto = string.Empty;
            Categoria = string.Empty;
            PrecoUnitario = 0;
        }
    }
}