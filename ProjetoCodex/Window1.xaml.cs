﻿using ProjetoCodex.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoCodex
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string senha = txtSenha.Password;
            string nome = txtNome.Text;
            string dataNascimentoString = txtIdade.Text;
            DateTime dataNascimento;
            //string bio = txtBio.Text;
            string email = txtEmail.Text;

            if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtSenha.Password.Equals("") && !txtSenhaconf.Password.Equals(""))

            {
                Regex regex = new Regex(@"^([\w.\-]+)@([\w\-]+)(\.\w{2,3})?((\.com\.br)?)?$");
                if (regex.IsMatch(txtEmail.Text))
                {

                    if (txtSenha.Password == txtSenhaconf.Password)
                    {
                        if (DateTime.TryParseExact(dataNascimentoString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                        {
                            int idade = Usuario.CalcularIdade(dataNascimento);
                            Usuario novoUsuario = new Usuario
                            {
                                Nome = txtNome.Text,
                                Email = txtEmail.Text,
                                DataDeNascimento = idade,
                                // Bio = txtBio.Text,
                                Senha = txtSenha.Password,
                            };
                            Usuario.AdicionarUsuario(novoUsuario);
                            MessageBox.Show("Usuario cadastrado");
                            Close();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Senhas diferentes!");
                    }
                }
                else
                {
                    MessageBox.Show("Email não corresponde ao formato!");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

       
            
        
        
    }
}
