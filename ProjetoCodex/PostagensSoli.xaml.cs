using ProjetoCodex.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetoCodex
{
    /// <summary>
    /// Lógica interna para PostagensSoli.xaml
    /// </summary>
    public partial class PostagensSoli : Window
    {
        public PostagensSoli(List<Postagem> postagens)
        {
        
            InitializeComponent();
            InitializeComponent();
            ListBoxPostagens.ItemsSource = postagens;
          
        }


    }
   
}
