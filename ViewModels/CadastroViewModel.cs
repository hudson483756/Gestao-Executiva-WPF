using System;
using System.Collections.Generic;
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

        // Propriedades observáveis para os campos de Input do Cliente
        [ObservableProperty] private string _razaoSocial = string.Empty;
        [ObservableProperty] private string _documento = string.Empty;
        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _telefone = string.Empty;

        // Coleção dinâmica que o DataGrid do WPF escuta automaticamente (corrigido { get; })
        public ObservableCollection<Cliente> Clientes { get; } = new();

        public CadastroViewModel(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            AtualizarLista();
        }

        [RelayCommand]
        private void SalvarCliente()
        {
            // Validação básica de negócio
            if (string.IsNullOrWhiteSpace(RazaoSocial) || string.IsNullOrWhiteSpace(Documento))
                return;

            var novoCliente = new Cliente(
                Id: 0, // SQLite gera o auto-incremento
                RazaoSocial: RazaoSocial,
                Documento: Documento,
                Email: string.IsNullOrWhiteSpace(Email) ? null : Email,
                Telefone: string.IsNullOrWhiteSpace(Telefone) ? null : Telefone,
                DataCadastro: DateTime.Now.ToString("yyyy-MM-dd")
            );

            _clienteRepository.Inserir(novoCliente);

            // Limpa a tela e atualiza a grid
            LimparCampos();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            Clientes.Clear();
            foreach (var cliente in _clienteRepository.ListarTodos())
            {
                Clientes.Add(cliente);
            }
        }

        private void LimparCampos()
        {
            RazaoSocial = string.Empty;
            Documento = string.Empty;
            Email = string.Empty;
            Telefone = string.Empty;
        }
    }
}