﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ProjetoCodex.Controller
{
    public class Postagem : INotifyPropertyChanged
    {
        private int likes;
        private int dislikes;
        

        public ObservableCollection<Usuario> LikedByUsers { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<Usuario> DislikedByUsers { get; set; } = new ObservableCollection<Usuario>();
        public event PropertyChangedEventHandler PropertyChangedPostagem; // Renomeando para evitar ambiguidade

        protected virtual void OnPropertyChangedPostagem(string propertyName)
        {
            PropertyChangedPostagem?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        private static int contadorID = -1;
        public int ID { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public Boolean Reacao { get; set; }

        public static List<Postagem> postagens { get; set; } = new List<Postagem>();

        public static event Action OnPostagensChanged;

        public Postagem(string Autor, string Conteudo)
        {
            ID = contadorID++;
            this.Conteudo = Conteudo;
            this.Autor = Autor;
            Likes = 0;
            Dislikes = 0;
        }

        public static void AdicionarPostagemAutorConteudo(string Autor, string Conteudo)
        {
            Postagem novaPostagem = new Postagem(Autor, Conteudo);
            postagens.Add(novaPostagem);
            OnPostagensChanged?.Invoke();
        }

        public static List<Postagem> ListarPostagens()
        {
            return postagens;
        }

        public static void ExcluirPostagemEspecifica(Postagem postagem)
        {
            if (postagens.Contains(postagem))
            {
                postagens.Remove(postagem);
                OnPostagensChanged?.Invoke();
            }
        }

        public void AdicionarComentario(string nome, string texto)
        {
            Comentarios.Add(new Comentario { Autor = nome, Texto = texto });

            OnPostagensChanged?.Invoke();

        }
       
        public static void ExcluirPostagem(Postagem postagem)
        {
            postagens.Remove(postagem);
            OnPostagensChanged?.Invoke();
        }
    }
}
