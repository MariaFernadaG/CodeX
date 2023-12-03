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
    /// <summary>
    /// Lógica interna para ConfiguracaoPage.xaml
    /// </summary>
    public partial class ConfiguracaoPage : Window
    {
        public ConfiguracaoPage()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;

            textBoxNome.Text = Usuario.UsuarioLogado.Nome;
            texteditarBio.Text = Usuario.UsuarioLogado.Bio;


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
        private void Editarperfil_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuariologado = Usuario.UsuarioLogado;

            // DateTime dataNascimento = ((DateTime?)txtData.SelectedDate)?.Date ?? DateTime.MinValue;

            Usuario.EditarUsuario(usuariologado, textBoxNome.Text);
        }

        private void editarbio_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuariologado = Usuario.UsuarioLogado;



            Usuario.EditarBio(usuariologado, texteditarBio.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerfilPage perfilPage = new PerfilPage();
            perfilPage.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NotificacaoPage notificacaoPage = new NotificacaoPage();
            notificacaoPage.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LogoutPage logoutPage = new LogoutPage();
            logoutPage.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TelaAcesso2 telaAcesso2 = new TelaAcesso2();
            telaAcesso2.Show();
            this.Close();

        }

      

        public void PreencherListBoxComSolicitacoes(ListBox ListSNotificacoes)
        {





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

        private void DesativarContaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja desativar sua conta?", "Confirmação", MessageBoxButton.YesNo);

            // Verificar a resposta do usuário
            if (result == MessageBoxResult.Yes)
            {
                Usuario usuarioAtual = Usuario.UsuarioLogado;

                // Desativa a conta e arquiva as postagens
                usuarioAtual.DesativarConta();

                MessageBox.Show("Conta desativada com sucesso!");
                this.Close();
                MainWindow n2 = new MainWindow();
                n2.Show();
            }
            else
            {
                
            }

        }
    }
}
