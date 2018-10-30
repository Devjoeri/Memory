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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Deze class bevat de button events voor het giveup pop-up,
    /// die verantwoordelijk zijn om of de game te stoppen en opteslaan, of terug te gaan naar de game
    /// </summary>
    public partial class Giveup : Page
    {
        public Giveup()
        {
            InitializeComponent();
        }

        private void giveup_Yes(object sender, RoutedEventArgs e)
        {

        }

        private void giveup_No(object sender, RoutedEventArgs e)
        {

        }
    }
}
