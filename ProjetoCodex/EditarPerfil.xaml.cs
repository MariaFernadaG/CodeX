using ProjetoCodex.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ProjetoCodex
{
    /// <summary>
    /// Interação lógica para EditarPerfil.xam
    /// </summary>
    public partial class EditarPerfil : Page
    {
        public EditarPerfil()
        {
            InitializeComponent();
            textNovoNome.Text = Usuario.UsuarioLogado.Nome;
            textBoxNovoEmail.Text = Usuario.UsuarioLogado.Email;
            textBoxNovaBio.Text = " ";
        }

        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioLogado = Usuario.UsuarioLogado;

            // Obtendo os novos valores dos TextBoxes
            string novoNome = textNovoNome.Text;
            //tring novaDataNascimentoStr = textBoxNovaDataNascimento.Text; // Supondo que a data seja inserida como string no formato válido (dd/mm/yyyy)
            string novoEmail = textBoxNovoEmail.Text;
            string novaBio = textBoxNovaBio.Text;

            // Alterar o nome se não estiver vazio
            if (!string.IsNullOrEmpty(novoNome))
            {
                usuarioLogado.Nome = novoNome;
            }

          

            // Alterar o email se não estiver vazio
            if (!string.IsNullOrEmpty(novoEmail))
            {
                usuarioLogado.Email = novoEmail;
            }

            // Adicionar a bio se não estiver vazia
            if (!string.IsNullOrEmpty(novaBio))
            {
                usuarioLogado.Bio = novaBio;
            }

            // Exibindo uma mensagem de confirmação ou realizando outra ação após as alterações
            MessageBox.Show("Alterações realizadas com sucesso!");

            // Limpar os TextBoxes após as alterações
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerfilPage page = new PerfilPage();
            page.Show();
        }
    }
}

