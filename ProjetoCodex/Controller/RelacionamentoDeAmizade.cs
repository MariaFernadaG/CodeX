using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetoCodex.Controller
{
    class RelacionamentoDeAmizade
    {
        public int UsuarioId { get; set; }
        public int AmigoId { get; set; }
        public bool Aceita { get; set; }

        public static List<RelacionamentoDeAmizade> RelacionamentosDeAmizade = new List<RelacionamentoDeAmizade>();
       


       

        
    }
    
}