using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCodex.Controller
{
    public class Notificacao
    {
        public int ID { set; get; }
        public string Titulo { set; get; }
        public string Conteudo { set; get; }
        public Usuario Destinatario { set; get; }
        public static List<Notificacao> listaNotificacoes { get; set; } = new List<Notificacao>();
        public static int contadorNot = 0;

        public Notificacao()
        {

        }

        public static void AdicionarNotificacao(Notificacao notificacao)
        {
            listaNotificacoes.Add(notificacao);
            contadorNot++;
        }

        public static List<Notificacao> ListarNotificacoes()
        {
            return listaNotificacoes;
        }
    }
}

