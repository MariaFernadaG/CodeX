using System.Collections.Generic;
using System.Windows;

namespace ProjetoCodex.Controller
{
    public static class WindowManager
    {
        private static List<Window> janelasAbertas = new List<Window>();

        public static void AbrirJanela(Window janela)
        {
            janelasAbertas.Add(janela);
            janela.Closed += (s, e) => janelasAbertas.Remove(janela);
            janela.Show();
        }

        public static void FecharTodasAsJanelas()
        {
            foreach (var janela in janelasAbertas)
            {
                janela.Close();
            }
            janelasAbertas.Clear();
        }

        public static List<Window> GetJanelasAbertas()
        {
            return janelasAbertas;
        }
    }
}
