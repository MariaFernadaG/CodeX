using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetoCodex.Controller
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Bio { get; set; }
        public string Senha { get; set; }
        public int User { get; set; }

        public static DateTime DataDeNascimentoPadrao = new DateTime(2000, 1, 1);

        public static DateTime CalcularDataNascimento(int idade)
        {
            if (idade <= 0)
            {
                // Caso a idade seja inválida, retorne a data mínima possível (por exemplo, 1º de janeiro de 1900).
                return new DateTime(1900, 1, 1);
            }

            int anoAtual = DateTime.Now.Year;
            int mesNascimento = 1;
            int diaNascimento = 1;

            if (DateTime.Now.Month < mesNascimento || (DateTime.Now.Month == mesNascimento && DateTime.Now.Day < diaNascimento))
            {
                anoAtual--;
            }

            int anoNascimento = anoAtual - idade;
            return new DateTime(anoNascimento, mesNascimento, diaNascimento);
        }


        public static Usuario UsuarioLogado { get; private set; }

        public static List<Usuario> listausuario = new List<Usuario>
        {
            new Usuario
            {
                ID = 0,
                Nome = "Maria Fernanda Guedes",
                DataDeNascimento = new DateTime(2003, 1, 1),  // Use a data de nascimento correta
                Email = "Maria@gmail.com",
                Senha = "123"

            },
            new Usuario
            {
                ID = 1,
                Nome = "Pedro Luiz",
                DataDeNascimento = new DateTime(2002, 1, 1),  // Use a data de nascimento correta
                Email = "Pedro@gmail.com",
                Senha = "123"
            }
        };

        public Usuario()
        {
            listausuario ??= new List<Usuario>();
            ID = Usuario.listausuario.Count;
        }

        public Usuario(int iD, string nome, string email, DateTime dataNascimento, string bio, string senha)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            DataDeNascimento = dataNascimento;
            Bio = bio;
            Senha = senha;
        }

        public static void AdicionarUsuario(Usuario usuario, int idade)
        {
            DateTime dataNascimento = Usuario.CalcularDataNascimento(idade);
            Usuario novoUsuario = new Usuario(usuario.ID, usuario.Nome, usuario.Email, dataNascimento, usuario.Bio, usuario.Senha);
            listausuario.Add(novoUsuario);
        }

        public static bool VerificarEmailIguais(string email)
        {
            return listausuario.Any(u => u.Email == email);
        }

        public static Usuario ObterUsuarioPorID(int id)
        {
            return listausuario.FirstOrDefault(usuario => usuario.ID == id);
        }

        public static bool VerificarEmailExiste(string? email)
        {
            return listausuario.Any(u => u.Email == email);
        }

        public static Usuario BuscarUsuario(string email, string senha)
        {
            return listausuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public static Usuario BuscarUsuarioEmailOuID(string emailOuID)
        {
            if (int.TryParse(emailOuID, out int id))
            {
                return listausuario.FirstOrDefault(u => u.ID == id);
            }
            else
            {
                return listausuario.FirstOrDefault(u => u.Email.Equals(emailOuID, StringComparison.OrdinalIgnoreCase));
            }
        }

        public static bool FazerLogin(string email, string senha)
        {
            Usuario usuario = listausuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                MessageBox.Show("Usuário não encontrado");
                return true;
            }
            else
            {
                UsuarioLogado = usuario;
                return false;
            }
        }

        public static void RealizarLogout()
        {
            UsuarioLogado = null;
        }

        public static int CalcularIdade(DateTime dataDeNascimento)
        {
            int idade = DateTime.Now.Year - dataDeNascimento.Year;

            if (DateTime.Now.Month < dataDeNascimento.Month || (DateTime.Now.Month == dataDeNascimento.Month && DateTime.Now.Day < dataDeNascimento.Day))
            {
                idade--;
            }

            return idade;
        }

        public static DateTime ObterDataNascimento(int idade)
        {
            DateTime dataAtual = DateTime.Now;
            int anoNascimento = dataAtual.Year - idade;
            int mesNascimento = dataAtual.Month;
            int diaNascimento = dataAtual.Day;

            if (dataAtual.Month < mesNascimento || (dataAtual.Month == mesNascimento && dataAtual.Day < diaNascimento))
            {
                anoNascimento--;
            }

            return new DateTime(anoNascimento, mesNascimento, diaNascimento);
        }
    }
}
