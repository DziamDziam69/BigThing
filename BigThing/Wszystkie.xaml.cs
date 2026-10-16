using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BigThing
{
    public partial class Wszystkie : Window
    {
        public Wszystkie(List<MainWindow.Gra> gry)
        {
            InitializeComponent();

            DataContext = gry;
        }
        private void Button_Zamknij_Click(object sender, EventArgs e)
        { 
            Close();
        }
    }
}
