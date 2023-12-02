using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCodex.Controller
{
    public class Notificacao
    {
        public string Mensagem { get; set; }
        public Usuario Remetente { get; set; } // Adicione uma propriedade para armazenar o remetente da notificação

        public Notificacao(string mensagem, Usuario remetente)
        {
            Mensagem = mensagem;
            Remetente = remetente;
        }
    }
}

