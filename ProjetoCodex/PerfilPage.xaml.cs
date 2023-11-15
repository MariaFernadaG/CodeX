using ProjetoCodex.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace ProjetoCodex
{
    public partial class PerfilPage : Window
    {
        public ObservableCollection<Postagem> PostagensDoUsuarioLogado { get; set; }
        private static List<Window> janelasAbertas = new List<Window>();
      
        public PerfilPage()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;
            txtIdade.Text = Usuario.UsuarioLogado.DataDeNascimento.ToString();
            PostagensDoUsuarioLogado = new ObservableCollection<Postagem>();

            // Preenche a lista de postagens do usuário logado
            foreach (var postagem in Postagem.postagens.Where(p => p.Autor == Usuario.UsuarioLogado.Nome))
            {
               
                PostagensDoUsuarioLogado.Add(postagem);
            }

            // Defina o DataContext para a instância da PerfilPage
            DataContext = this;

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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TelaAcesso2 telaAcesso2 = new TelaAcesso2();    
            telaAcesso2.Show();
            this.Close();
        }
       
    }
    
}
