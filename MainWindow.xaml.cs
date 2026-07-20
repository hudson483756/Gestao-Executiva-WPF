using System;
using System.Windows;
using Projeto1_Excel.ViewModels;

namespace Projeto1_Excel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                // Se a MainViewModel falhar ao ser criada, o catch vai capturar
                DataContext = new MainViewModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar a janela principal:\n\n{ex.Message}\n\n{ex.InnerException?.Message}",
                                "Erro de Inicialização",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}