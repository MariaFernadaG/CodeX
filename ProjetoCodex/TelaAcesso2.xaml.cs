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
using System.Windows.Shapes;

namespace ProjetoCodex
{
    /// <summary>
    /// Lógica interna para TelaAcesso2.xaml
    /// </summary>
    public partial class TelaAcesso2 : Window
    {
        public TelaAcesso2()
        {
            InitializeComponent();
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtNome.Text = Usuario.UsuarioLogado.Nome;
            txtIdade.Text = Usuario.UsuarioLogado.DataDeNascimento.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Perfil telaperfil = new Perfil();
            telaperfil.Show();
        }
    }
}
