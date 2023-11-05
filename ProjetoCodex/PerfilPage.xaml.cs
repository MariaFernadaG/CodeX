using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjetoCodex
{
    public partial class PerfilPage : Window
    {
        private static List<Window> janelasAbertas = new List<Window>();

        public PerfilPage()
        {
            InitializeComponent();
     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerfilPage perfilPage = new PerfilPage();
            perfilPage.Show();

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        

           LogoutPage logoutPage = new LogoutPage();
           logoutPage.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ConfiguracaoPage configuracaoPage = new ConfiguracaoPage(); 
            configuracaoPage.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NotificacaoPage notificacaoPage = new NotificacaoPage();
            notificacaoPage.Show();
            this.Close();
        }
    }
}
