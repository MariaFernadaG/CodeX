using ProjetoCodex.Controller;
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
using System.Windows.Threading;

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
            txtIdade.Text = Usuario.UsuarioLogado.DataDeNascimento.ToString();
           
            Usuario.UsuarioLogado.MostrarNotificacoesPublico();


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
        public void PreencherListBoxComUsuarios(ListBox ListSolicitacoes)
        {

            foreach (var notificacao in Usuario.UsuarioLogado.Notificacoes)
            {
                ListSNotificacoes.Items.Add(notificacao.Remetente);

            }

        }
        private void AceitarSolicitacao_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Usuario remetente = button?.Tag as Usuario;

            if (remetente != null)
            {
                // Aceitar a solicitação de amizade
                Usuario.UsuarioLogado.AceitarSolicitacaoAmizade(remetente);

                // Remover a notificação da lista
                Notificacao notificacao = Usuario.UsuarioLogado.Notificacoes.FirstOrDefault(n => n.Remetente == remetente);
                if (notificacao != null)
                {
                    Usuario.UsuarioLogado.Notificacoes.Remove(notificacao);
                }

                // Atualizar a interface do usuário
                AtualizarSolicitacoesAmizade();
            }
        }
        private void AtualizarSolicitacoesAmizade()
        {
            ListSNotificacoes.ItemsSource = null;
            ListSNotificacoes.ItemsSource = Usuario.UsuarioLogado.SolicitacoesAmizadePendentes;
        }
    }
}




