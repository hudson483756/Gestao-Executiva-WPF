using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto1_Excel.Views; // Caminho onde estão as UserControls

namespace Projeto1_Excel.ViewModels;

/// <summary>
/// ViewModel principal que gerencia o estado da aplicação e a navegação do Menu Hambúrguer.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    // Armazena as instâncias das Views em memória para evitar recriações desnecessárias
    private readonly object _cadastroView;
    private readonly object _financeiroView;
    private readonly object _relatoriosView;

    /// <summary>
    /// Propriedade que define qual View está ativa e visível no ContentControl da MainWindow.
    /// O Source Generator do Toolkit criará a propriedade pública "CurrentView" automaticamente.
    /// </summary>
    [ObservableProperty]
    private object? _currentView;

    /// <summary>
    /// Título dinâmico para a barra superior do sistema baseado na tela ativa.
    /// </summary>
    [ObservableProperty]
    private string _currentTitle = "Painel Inicial";

    // Construtor Principal (.NET 10 Style)
    public MainViewModel()
    {
        // Inicializa as views para navegação rápida
        _cadastroView = new CadastroView();
        _financeiroView = new FinanceiroView();
        _relatoriosView = new RelatoriosView();

        // Define a tela inicial padrão do sistema ao abrir
        NavegarParaCadastro();
    }

    /// <summary>
    /// Comando para ativar a tela de cadastros.
    /// O Toolkit gerará automaticamente o comando "NavegarParaCadastroCommand".
    /// </summary>
    [RelayCommand]
    private void NavegarParaCadastro()
    {
        CurrentView = _cadastroView;
        CurrentTitle = "📦 Gestão de Cadastros (Clientes & Produtos)";
    }

    /// <summary>
    /// Comando para ativar a tela de lançamentos financeiros.
    /// </summary>
    [RelayCommand]
    private void NavegarParaFinanceiro()
    {
        CurrentView = _financeiroView;
        CurrentTitle = "💰 Movimentações & Fluxo de Vendas";
    }

    /// <summary>
    /// Comando para ativar a tela de geração de relatórios.
    /// </summary>
    [RelayCommand]
    private void NavegarParaRelatorios()
    {
        CurrentView = _relatoriosView;
        CurrentTitle = "📊 Inteligência de Dados & Exportação Executiva";
    }
}