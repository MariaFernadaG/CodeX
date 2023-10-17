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
        public int DataDeNascimento { get; set; }
        public string Bio { get; set; }
        public string Senha { get; set; }
        public int User { get; set; }
        
        public static Usuario? UsuarioLogado { get; private set; }


        public static List<Usuario> listausuario = new List<Usuario>() {
        new Usuario{
            ID= 0,
            Nome= "Maria Fernanda Guedes",
            DataDeNascimento= 20,
            Email= "Maria@gmail.com",
            Senha="123"
            },
        new Usuario{
            ID= 1,
            Nome= "Pedro Luiz",
            DataDeNascimento= 19,
            Email= "Pedro@gmail.com",
            Senha="123"

        }
        };
        public Usuario() {
        listausuario ??= new List<Usuario>();
        ID= Usuario.listausuario.Count;
        
        }
        public Usuario(int iD, string nome, string email, int idade, string bio, string senha)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            DataDeNascimento = idade;
            Bio = bio;
            Senha = senha;
        }   

        public static void AdicionarUsuario(Usuario usuario)
        {
            listausuario.Add(usuario);

        }
        //verifica se tem email iguais 
        public static bool VerificarEmailIguais(string email)
        {
            return listausuario.Any(u=> u.Email == email);

        }
        //busca por id o usaurio
        public static Usuario ObterUsuarioPorID(int id)
        {
            foreach(Usuario usuario in listausuario)
            { 
            if(usuario.ID == id)
                {
                    return usuario;
                }
            
            }
            return null;
        }

        // Verifica se existe 2 e-mails iguais
        public static bool VerificarEmailExiste(string? email)
        {
            return listausuario.Any(u => u.Email == email);
        }

        
        public static Usuario BuscarUsuario(string email, string senha)
        {
            return listausuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        // Busca o usuário pelo seu e-mail ou pelo seu ID
        public static Usuario BuscarUsuarioEmailOuID(string emailOuID)
        {
            if (int.TryParse(emailOuID, out int id))
            {
                return listausuario.FirstOrDefault(u => u.ID == id);
            }
            else
            {
                return listausuario.FirstOrDefault(u => u.Email.ToLower() == emailOuID.ToLower());
            }
        }



        public static bool FazerLogin(string email, string senha)
        {

            Usuario usuario = listausuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
               
                MessageBox.Show("Usuario nao encontrado");
                return true;

            }
            else
            {
                UsuarioLogado = usuario;
                return false;
            }
        }

        // idade 
        // Tente converter o texto da data de nascimento em uma data.

        public static int CalcularIdade(DateTime datadeNascimento)
        {
            int idade = DateTime.Now.Year - datadeNascimento.Year;

            if (DateTime.Now.Month < datadeNascimento.Month || (DateTime.Now.Month == datadeNascimento.Month && DateTime.Now.Day < datadeNascimento.Day))
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
