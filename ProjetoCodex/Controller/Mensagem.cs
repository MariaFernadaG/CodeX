using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCodex.Controller
{
    public class Mensagem
    {
        public int ID { get; set; }
        public Usuario Destinatario { get; set; }
        public Usuario Remetente { get; set; }
        public string Conteudo { get; set; }

        public static void EnviarMensagem()
        {

        }
        public static void VerMensagem()
        {

        }
        public static void ResponderMensagem()
        {

        }

    }
}

