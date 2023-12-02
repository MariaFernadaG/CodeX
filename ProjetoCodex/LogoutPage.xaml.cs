using ProjetoCodex.Controller;
using System.Collections.Generic;
using System.Windows;

namespace ProjetoCodex
{
    public partial class LogoutPage : Window
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            // Feche as cópias das janelas
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this)
                {
                    window.Close();
                }
            }
            55
            // Abra a tela inicial
            MainWindow telaInicial = new MainWindow();
            WindowManager.AbrirJanela(telaInicial);

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
