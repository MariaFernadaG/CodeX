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
    /// Lógica interna para NotificacaoPage.xaml
    /// </summary>
    public partial class NotificacaoPage : Window
    {
        public NotificacaoPage()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;
           

            //Usuario.UsuarioLogado.MostrarNotificacoesPublico();

            Usuario usuarioLogado = Usuario.UsuarioLogado;

            ListAmigos.ItemsSource = Usuario.UsuarioLogado.Amigos;
            ListSNotificacoes.ItemsSource = Usuario.UsuarioLogado.Notificacoes;


        }
        public void PreencherListBoxComNotificoes()
        {
            ListSNotificacoes.Items.Clear();

            foreach (var notificacao in Usuario.UsuarioLogado.Notificacoes)
            {
                ListSNotificacoes.Items.Add(notificacao.Mensagem);
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
            ConfiguracaoPage configuracaoPage = new ConfiguracaoPage();
            configuracaoPage.Show();
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
      

       
        private void AtualizarListaAmigos()
        {
            // Associa a lista de amigos à fonte de dados do ListBox
            ListAmigos.ItemsSource = Usuario.UsuarioLogado.Amigos;
        }
        private void AceitarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Notificacao notificacao = button.DataContext as Notificacao;

                if (notificacao != null)
                {
                    // Remove a notificação após aceitar a solicitação
                    Usuario.UsuarioLogado.RemoverNotificacao(notificacao);

                    Usuario remetente = notificacao.Remetente; // Supondo que Notificacao tenha um campo Remetente
                    if (remetente != null)
                    {
                        // Remove a notificação após aceitar a solicitação
                        Usuario.UsuarioLogado.RemoverNotificacao(notificacao);
                       
                        // Adiciona o remetente como amigo do usuário logado
                        Usuario.UsuarioLogado.Amigos.Add(remetente);

                        // Remove a solicitação pendente, se existir
                        Usuario.UsuarioLogado.SolicitacoesAmizadePendentes.Remove(remetente);

                        // Atualiza a interface após as alterações
                        AtualizarListaAmigos(); // Atualiza a lista de amigos

                        // Atualiza as fontes de dados dos outros controles
                        ListSNotificacoes.ItemsSource = Usuario.UsuarioLogado.Notificacoes;
                       // ListSugestoes.ItemsSource = Usuario.listausuario.Where(u => u != Usuario.UsuarioLogado && !Usuario.UsuarioLogado.Amigos.Contains(u));
                    }
                }
            }
        }


        private void RecusarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Notificacao notificacao = button.DataContext as Notificacao;

                if (notificacao != null)
                {
                    Usuario.UsuarioLogado.RemoverNotificacao(notificacao);
                    ListSNotificacoes.ItemsSource = null;
                    ListSNotificacoes.ItemsSource = Usuario.UsuarioLogado.Notificacoes;
                }
            }


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

        private void ListSNotificacoes_SelectionChanged()
        {

        }
    }
}




