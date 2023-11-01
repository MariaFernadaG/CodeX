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

namespace ProjetoCodex
{
    public partial class TelaAcesso2 : Window
    {
        private DispatcherTimer timer;
        public ObservableCollection<Postagem> Postagens { get; set; } = new ObservableCollection<Postagem>();

        private TextBox comentarioTextBox;

        private int maxLikesPerPost = 1;


        public TelaAcesso2()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;
            txtIdade.Text = Usuario.UsuarioLogado.DataDeNascimento.ToString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();

            listaPostagens.ItemsSource = Postagens;
            comentarioTextBox = (TextBox)FindName("comentarioTextBox");
            Postagem.OnPostagensChanged += AtualizarPostagens;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Perfil telaperfil = new Perfil();
            telaperfil.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Postagem.AdicionarPostagemAutorConteudo(txtNome.Text, campoMensagem.Text);
            campoMensagem.Text = "";
        }

        private void botaoEnviarPublicacao_Click(object sender, RoutedEventArgs e)
        {
            Postagem.AdicionarPostagemAutorConteudo(txtNome.Text, campoMensagem.Text);
            campoMensagem.Text = "";
        }

        private void listaPostagens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (var postagem in Postagem.postagens)
            {
                if (!Postagens.Contains(postagem))
                {
                    Postagens.Add(postagem);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Usuario.RealizarLogout();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            Button likeButton = (Button)sender;
            Postagem postagem = (Postagem)likeButton.DataContext;

            if (postagem.LikedByUsers.Contains(Usuario.UsuarioLogado))
            {
                postagem.Likes--; // Reverter a curtida
                postagem.LikedByUsers.Remove(Usuario.UsuarioLogado); // Remover o usuário da lista de quem curtiu
            }
            else if (postagem.DislikedByUsers.Contains(Usuario.UsuarioLogado))
            {
                // O usuário havia descurtido, mas agora curte a postagem
                postagem.Likes++;
                postagem.LikedByUsers.Add(Usuario.UsuarioLogado);

                postagem.Dislikes--; // Reverter o descurtir
                postagem.DislikedByUsers.Remove(Usuario.UsuarioLogado); // Remover o usuário da lista de quem descurtiu
            }
            else
            {
                postagem.Likes++; // Adicionar uma curtida
                postagem.LikedByUsers.Add(Usuario.UsuarioLogado); // Adicionar o usuário à lista de quem curtiu
            }
        }

        private void DislikeButton_Click(object sender, RoutedEventArgs e)
        {
            Button dislikeButton = (Button)sender;
            Postagem postagem = (Postagem)dislikeButton.DataContext;

            if (postagem.DislikedByUsers.Contains(Usuario.UsuarioLogado))
            {
                postagem.Dislikes--; // Reverter o descurtir
                postagem.DislikedByUsers.Remove(Usuario.UsuarioLogado); // Remover o usuário da lista de quem descurtiu
            }
            else if (postagem.LikedByUsers.Contains(Usuario.UsuarioLogado))
            {
                // O usuário havia curtido, mas agora descurte a postagem
                postagem.Dislikes++;
                postagem.DislikedByUsers.Add(Usuario.UsuarioLogado);

                postagem.Likes--; // Reverter a curtida
                postagem.LikedByUsers.Remove(Usuario.UsuarioLogado); // Remover o usuário da lista de quem curtiu
            }
            else
            {
                postagem.Dislikes++; // Adicionar um descurtir
                postagem.DislikedByUsers.Add(Usuario.UsuarioLogado); // Adicionar o usuário à lista de quem descurtiu
            }
        }


        private void AdicionarComentarioButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtém o botão que foi clicado
            Button adicionarComentarioButton = (Button)sender;

            // A partir do botão, obtenha a postagem à qual deseja adicionar um comentário
            Postagem postagem = (Postagem)adicionarComentarioButton.DataContext;

            // Aqui, você pode obter o autor e texto do comentário de alguma entrada do usuário, por exemplo:
            string autor = "Nome do Autor";
            string textoComentario = "Texto do Comentário";

            // Chame o método AdicionarComentario da postagem para adicionar o novo comentário
            postagem.AdicionarComentario(autor, textoComentario);
        }
        private void EnviarComentarioButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenha o item da ListBox selecionado (a postagem à qual você deseja adicionar o comentário)
            Postagem postagem = (Postagem)listaPostagens.SelectedItem;

            if (postagem != null)
            {
                // Obtenha o texto do comentário do TextBox
                string comentario = comentarioTextBox.Text;

                // Verifique se o comentário não está vazio
                if (!string.IsNullOrWhiteSpace(comentario))
                {
                    // Adicione o comentário à postagem
                    postagem.AdicionarComentario(Usuario.UsuarioLogado.Nome, comentario);

                    // Limpe o TextBox após adicionar o comentário
                    comentarioTextBox.Text = ""; // Em vez de atualizar comentarioTextBox, você deve limpar o texto do TextBox diretamente
                }
            }
        }
        private void ExcluirPostagemButton_Click(object sender, RoutedEventArgs e)
        {
            Button excluirButton = (Button)sender;
            Postagem postagem = (Postagem)excluirButton.DataContext;

            // Verifique se o usuário logado é o autor da postagem
            if (postagem.Autor == Usuario.UsuarioLogado.Nome)
            {
                // Remova a postagem da fonte de dados
                Postagem.ExcluirPostagemEspecifica(postagem);
            }
            else
            {
                MessageBox.Show("Você não tem permissão para excluir esta postagem.");
            }
        }
        private void AtualizarPostagens()
        {
            // Atualize a lista de Postagens com as postagens existentes em Postagem.postagens
            Postagens.Clear();
            foreach (var postagem in Postagem.postagens)
            {
                Postagens.Add(postagem);
            }
        }

        private void txtIdade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
