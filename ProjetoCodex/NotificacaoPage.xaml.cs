using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoCodex
{
    /// <summary>
    /// Interação lógica para NotificacaoPage.xam
    /// </summary>
    public partial class NotificacaoPage : Window
    {
        public NotificacaoPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogoutPage logoutPage = new LogoutPage();   
            logoutPage.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConfiguracaoPage configuracaoPage = new ConfiguracaoPage();
            configuracaoPage.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PerfilPage perfilPage = new PerfilPage();
            perfilPage.Show();
            this.Close();
        }
    }
}
