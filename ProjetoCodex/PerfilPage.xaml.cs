using MaterialDesignThemes.Wpf;
using ProjetoCodex.Controller;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel; // Adicione esta linha
using System.Windows; // Adicione esta linha
using static ProjetoCodex.Controller.Usuario;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

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
           
            PostagensDoUsuarioLogado = new ObservableCollection<Postagem>();
           
            foreach (var postagem in Postagem.postagens.Where(p => p.Autor == Usuario.UsuarioLogado.Nome))
            {

                PostagensDoUsuarioLogado.Add(postagem);
            }

            // Defina o DataContext para a instância da PerfilPage
            DataContext = this;

            Usuario usuarioLogado = Usuario.UsuarioLogado;

            Usuario.UsuarioLogado.ContaDesativada += UsuarioDesativouConta;
            AtualizarListaAmigos();

        }
        private void UsuarioDesativouConta(object sender, EventArgs e)
        {
            AtualizarListaAmigos();
        }
        private void AtualizarListaAmigos()
        {
            if (Usuario.UsuarioLogado != null)
            {
                var amigosAtivos = Usuario.UsuarioLogado.Amigos.Where(amigo => amigo.Ativa).ToList();
                listBoxAmigos.ItemsSource = amigosAtivos;
            }
            else
            {
                listBoxAmigos.ItemsSource = null;
            }
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

        
      
       

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
