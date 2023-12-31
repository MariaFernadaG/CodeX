﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetoCodex.Controller.Postagem;

namespace ProjetoCodex.Controller
{
    public class Arquivador
    {
        public static List<Postagem> PostagensArquivadas { get; set; } = new List<Postagem>();
        public static List<Comentario> ComentariosArquivados { get; set; } = new List<Comentario>();

        public static void ArquivarPostagensEComentarios(Usuario usuario)
        {
         
            List<Postagem> postagensDoUsuario = Postagem.ListarPostagens().Where(p => p.Autor == usuario.Nome).ToList();
            PostagensArquivadas.AddRange(postagensDoUsuario);

          
            foreach (Postagem postagem in postagensDoUsuario)
            {
                Postagem.ExcluirPostagemEspecifica(postagem);
            }

            
            foreach (Postagem postagem in postagensDoUsuario)
            {
                ComentariosArquivados.AddRange(postagem.Comentarios);
            }
        }

        public static void RestaurarPostagensEComentarios(Usuario usuario)
        {

            List<Postagem> postagensRestauradas = PostagensArquivadas.Where(p => p.Autor == usuario.Nome).ToList();
            foreach (Postagem postagem in postagensRestauradas)
            {
                Postagem.AdicionarPostagemAutorConteudo(postagem.Autor, postagem.Conteudo);
            }


            foreach (Postagem postagem in postagensRestauradas)
            {
                PostagensArquivadas.Remove(postagem);
            }


            foreach (Comentario comentario in ComentariosArquivados)
            {
                foreach (Postagem postagem in postagensRestauradas)
                {
                    if (postagem.Comentarios.Contains(comentario))
                    {
                        postagem.AdicionarComentario(comentario.Autor, comentario.Texto);
                    }
                }
            }

            
            ComentariosArquivados.RemoveAll(c => postagensRestauradas.Any(p => p.Comentarios.Contains(c)));
        }

    }
}
