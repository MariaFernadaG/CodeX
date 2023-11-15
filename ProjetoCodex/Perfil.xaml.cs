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
    /// Lógica interna para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        public Perfil()
        {
            InitializeComponent();
            textNovoNome.Text = Usuario.UsuarioLogado.Nome;
            textBoxNovoEmail.Text = Usuario.UsuarioLogado.Email;
            textBoxNovaBio.Text = " ";

        }


        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            /*Usuario usuarioLogado = ;

            // Alterar o nome do usuário
            usuarioLogado.AlterarNome(textNovoNome.Text);

            // Alterar a data de nascimento do usuário
            //DateTime novaDataNascimento = /* Lógica para converter o texto da data de nascimento ;
            usuarioLogado.AlterarDataNascimento(novaDataNascimento);

            // Alterar o email do usuário
            usuarioLogado.AlterarEmail(textBoxNovoEmail.Text);*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerfilPage page = new PerfilPage();
            page.Show();
        }
    }
}
