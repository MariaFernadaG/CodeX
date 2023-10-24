using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetoCodex.Controller
{
    public class Postagem : INotifyPropertyChanged
    {
        private int likes;
        private int dislikes;

        public class Comentario
        {
            public string Autor { get; set; }
            public string Texto { get; set; }
        }

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();


        public int Likes
        {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        public int Dislikes
        {
            get { return dislikes; }
            set
            {
                dislikes = value;
                OnPropertyChanged(nameof(Dislikes));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private static int  contadorID=-1;
        public int ID { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public Boolean Reacao { get; set; }
      



        public static List<Postagem> postagens { get; set; } = new List<Postagem>();

       /* public Postagem(string assunto,string conteudo, Usuario autor,string categoria, Boolean reacao)
        {
            ID = contadorID++;
            Assunto = assunto;
            Conteudo = conteudo;
            Autor = autor;
            Categoria = categoria;
            Reacao = reacao;

            
        }*/
        public Postagem(string Autor,string Conteudo)
        {
            ID = contadorID++;
            this.Conteudo = Conteudo;
            this.Autor = Autor;
            Likes = 0;
            Dislikes = 0;
        }
        //criar postagem pre definidas 


        
        //adicionar postagem
        public static void AdionarPostagem(Postagem postagem)
        {
         postagens.Add(postagem);
        }
        public static void AdicionarPostagemAutorConteudo(string Autor, string Conteudo)

        {
            Postagem novaPostagem = new Postagem(Autor, Conteudo);
            postagens.Add(novaPostagem);
        }
        //retorna postagens
        public static List<Postagem> ListarPostagens()
        {
            foreach (var postagem in postagens)
            {
                MessageBox.Show($"ID: {postagem.ID} \n Autor: {postagem.Autor} \n Conteúdo: {postagem.Conteudo}");
                Console.WriteLine($"Autor: {postagem.Autor}");
                Console.WriteLine($"Conteúdo: {postagem.Conteudo}");
                Console.WriteLine(); // Linha em branco entre as postagens
            }
            return postagens;
        }
        public void AdicionarComentario(string autor, string texto)
        {
            Comentarios.Add(new Comentario { Autor = autor, Texto = texto });
        }
        public static void ExcluirPostagem(Postagem postagem)
        {
            postagens.Remove(postagem);
           
        }
        public static void ReagirPostagem()
        {

        }
        public static void EditarPostagem()
        {

        }
    }
}

