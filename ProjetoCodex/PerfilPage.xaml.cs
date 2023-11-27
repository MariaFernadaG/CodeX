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
            textBoxNome.Text = Usuario.UsuarioLogado.Nome;
            texteditarBio.Text = Usuario.UsuarioLogado.Bio;
            foreach (var postagem in Postagem.postagens.Where(p => p.Autor == Usuario.UsuarioLogado.Nome))
            {

                PostagensDoUsuarioLogado.Add(postagem);
            }

            // Defina o DataContext para a instância da PerfilPage
            DataContext = this;

            Usuario usuarioLogado = Usuario.UsuarioLogado;

            ListSugestoes.ItemsSource = Usuario.listausuario.Where(u => u != UsuarioLogado);

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

        public void PreencherListBoxComUsuarios(ListBox listBox)
        {


            foreach (Usuario usuario in Usuario.listausuario)
            {
                ListSugestoes.Items.Add(usuario.Nome);
                ListSugestoes.Items.Add(usuario.ID);


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
        public void PreencherListBoxComSolicitacoes(ListBox ListSNotificacoes)
        {





        }

        private void SolicitarAmizade_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioSelecionado = (Usuario)ListSugestoes.SelectedItem;

            if (usuarioSelecionado != null)
            {
                // Verifique se já existe uma solicitação de amizade pendente
                if (!Usuario.UsuarioLogado.SolicitacoesAmizadePendentes.Contains(usuarioSelecionado))
                {
                    // Envie a solicitação de amizade para o usuário selecionado
                    Usuario.UsuarioLogado.EnviarSolicitacaoAmizade(usuarioSelecionado);

                    // Atualize a interface do usuário ou forneça um feedback adequado
                    MessageBox.Show("Solicitação de amizade enviada para " + usuarioSelecionado.Nome);



                    // Atualize a ListBox com a nova fonte de dados
                    // ListSugestoes.ItemsSource = Usuario.listausuario.Where(u => u != Usuario.UsuarioLogado).ToList();
                    List<Usuario> novaListaUsuarios = Usuario.listausuario
                   .Where(u => u != Usuario.UsuarioLogado && u != usuarioSelecionado)
                   .ToList();

                    // Atualize a ListBox com a nova fonte de dados
                    ListSugestoes.ItemsSource = novaListaUsuarios;

                }
                else
                {
                    MessageBox.Show("Você já enviou uma solicitação de amizade para " + usuarioSelecionado.Nome);
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
    }
}
