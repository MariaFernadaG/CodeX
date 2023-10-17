using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCodex.Controller
{
    public class Postagem
    {
        private static int  contadorID=-1;
        public int ID { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Usuario Autor { get; set; }
        public string Categoria { get; set; }
        public Boolean Reacao { get; set; }


        public static List<Postagem> postagens { get; set; } = new List<Postagem>();

        public Postagem(string assunto,string conteudo, Usuario autor,string categoria, Boolean reacao)
        {
            ID = contadorID++;
            Assunto = assunto;
            Conteudo = conteudo;
            Autor = autor;
            Categoria = categoria;
            Reacao = reacao;

            
        }

        //criar postagem pre definidas 



        //adicionar postagem
        public static void AdionarPostagem(Postagem postagem)
        {
         postagens.Add(postagem);
        }
        //retorna postagens
        public static List<Postagem> ListarPostagens()
        {
            return postagens;
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

