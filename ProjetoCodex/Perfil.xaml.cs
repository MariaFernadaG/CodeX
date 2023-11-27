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
            txtNome.Text = Usuario.UsuarioLogado.Nome;
            txtEmail.Text = Usuario.UsuarioLogado.Email;
            txtBio.Text = Usuario.UsuarioLogado.Email;
        }
    }
}
