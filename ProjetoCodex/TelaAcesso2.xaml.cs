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
using ProjetoCodex;
namespace ProjetoCodex
{
    public partial class TelaAcesso2 : Window
    {
        private DispatcherTimer timer;
        public ObservableCollection<Postagem> Postagens { get; set; } = new ObservableCollection<Postagem>();



        private TextBox comentarioTextBox;

        private int maxLikesPerPost = 1;


        public ObservableCollection<Usuario> Usuarios { get; set; }
        public TelaAcesso2()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();

            // Inverta a ordem das postagens no início
            Postagem.postagens.Reverse();

            listaPostagens.ItemsSource = Postagens;
            comentarioTextBox = (TextBox)FindName("comentarioTextBox");
            Postagem.OnPostagensChanged += AtualizarPostagens;

            // Força a ordenação da lista de postagens na ordem correta (mais recente no topo)
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaPostagens.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Descending));
            //amizade
            // Substitua "usuarioLogado" pelo usuário atualmente logado no seu aplicativo.
            Usuario usuarioLogado = Usuario.UsuarioLogado;

            // modificaçao para nao aparecer usuario desativado 

            List<Usuario> sugestoes = UsuarioManager.ObterSugestoesParaUsuarioLogado();
            ListSugestoes.ItemsSource = sugestoes;



        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(campoMensagem.Text))
            {
                Postagem.AdicionarPostagemAutorConteudo(txtNome.Text, campoMensagem.Text);
                campoMensagem.Text = "";
            }
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
            LogoutPage janelaLogout = new LogoutPage();
            bool? resultado = janelaLogout.ShowDialog();

            if (resultado == true)
            {
                // Executar ações após o logout
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Caso o logout seja cancelado, não faz nada ou pode tratar isso de outra maneira
            }
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
            string autor = UsuarioLogado.Nome;
            string texto = comentarioTextBox.Text;

            // Chame o método AdicionarComentario da postagem para adicionar o novo comentário
            postagem.AdicionarComentario(autor, texto);
        }
        private void EnviarComentarioButton_Click(object sender, RoutedEventArgs e)
        { /// Obtenha a postagem selecionada


            Button button = sender as Button;
            if (button != null)
            {
                StackPanel stackPanel = button.Parent as StackPanel;
                if (stackPanel != null)
                {
                    TextBox comentarioTextBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault();
                    if (comentarioTextBox != null)
                    {
                        string textoComentario = comentarioTextBox.Text;
                        // Faça algo com o texto do comentário...

                        string autor = UsuarioLogado.Nome;
                        string texto = comentarioTextBox.Text;

                        Button adicionarComentarioButton = (Button)sender;

                        // A partir do botão, obtenha a postagem à qual deseja adicionar um comentário
                        Postagem postagem = (Postagem)adicionarComentarioButton.DataContext;

                        // Aqui, você pode obter o autor e texto do comentário de alguma entrada do usuário, por exemplo:

                        // Chame o método AdicionarComentario da postagem para adicionar o novo comentário
                        postagem.AdicionarComentario(autor, texto);
                    }
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
                // Exibir mensagem de confirmação
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja excluir esta postagem?", "Confirmação", MessageBoxButton.YesNo);

                // Verificar a resposta do usuário
                if (result == MessageBoxResult.Yes)
                {
                    // Remova a postagem da fonte de dados
                    Postagem.ExcluirPostagemEspecifica(postagem);
                }
                // Se o usuário clicar em "Não", não faça nada
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PerfilPage perfilPage = new PerfilPage();
            perfilPage.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            LogoutPage logoutPage = new LogoutPage();
            logoutPage.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ConfiguracaoPage configuracaoPage = new ConfiguracaoPage();
            configuracaoPage.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NotificacaoPage notificacaoPage = new NotificacaoPage();
            notificacaoPage.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            TelaAcesso2 telaAcesso2 = new TelaAcesso2();
            telaAcesso2.Show();
            this.Close();
        }

        public void PreencherListBoxComUsuarios(ListBox listBox)
        {


            foreach (Usuario usuario in Usuario.listausuario)
            {
                ListSugestoes.Items.Add(usuario.Nome);
                ListSugestoes.Items.Add(usuario.Bio);
                ListSugestoes.Items.Add(usuario.ID);


            }
        }

        private void listboxSugestao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListSugestoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ComentarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comentarioTextBox.Text))
            {
                // Adicione o comentário à listbox
                listaPostagens.Items.Add(comentarioTextBox.Text);
                comentarioTextBox.Text = string.Empty;
               
            }
        }


        private void VerPerfil_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioSelecionado = (Usuario)ListSugestoes.SelectedItem;

            if (usuarioSelecionado != null)
            {
                List<Postagem> postagensUsuarioSelecionado = ProjetoCodex.Controller.Postagem.ListarPostagens()
                    .Where(postagem => postagem.Autor == usuarioSelecionado.Nome)
                    .ToList();

                PostagensSoli novaTela = new PostagensSoli(postagensUsuarioSelecionado);
                novaTela.Show(); // Isso deveria mostrar a nova janela com as postagens do usuário selecionado
            }
        }

        private void SolicitarAmizade_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioSelecionado = (Usuario)ListSugestoes.SelectedItem;

            if (usuarioSelecionado != null)
            {
                if (!Usuario.UsuarioLogado.SolicitacoesAmizadePendentes.Contains(usuarioSelecionado))
                {
                    Usuario.UsuarioLogado.EnviarSolicitacaoAmizade(usuarioSelecionado);
                    MessageBox.Show("Solicitação de amizade enviada para " + usuarioSelecionado.Nome);

                    // Atualize a fonte de dados da ListBox
                    List<Usuario> sugestoesAtualizadas = ObterSugestoesDeAmizade();
                    ListSugestoes.ItemsSource = sugestoesAtualizadas;
                }
                else
                {
                    MessageBox.Show("Você já enviou uma solicitação de amizade para " + usuarioSelecionado.Nome);
                }
            }
        }

        private List<Usuario> ObterSugestoesDeAmizade()
        {
            return Usuario.listausuario
                .Where(u => u != Usuario.UsuarioLogado &&
                            !Usuario.UsuarioLogado.SolicitacoesAmizadePendentes.Contains(u))
                .ToList();
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


