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
    /// Interaction logic for NaamInvoer2.xaml
    /// </summary>
    public partial class NaamInvoer2 : Page
    {
        private string player1;
        private string player2;
        private int difficulty;
        private int gridsize;
        private string[] setup = new string[4];
        INavigator _navigator, _mainNav;
        NaamInvoerenWindow _window;
        public NaamInvoer2(NaamInvoerenWindow window, INavigator navigator, INavigator mainNav, string player1, int gridsize)
        {
            InitializeComponent();
            this.player1 = player1;
            this.gridsize = gridsize;
            _window = window;
            _mainNav = mainNav;
            _navigator = navigator;
        }

        public void Next(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(naamSpeler2.Text))
            {
                this.player2 = naamSpeler2.Text;
                if (player1 != player2)
                {
                    setup[1] = player1;
                    setup[2] = player2;
                    setup[3] = gridsize.ToString();
                    _mainNav.Navigate(new Game(_mainNav, setup));
                    //Ga terug naar main window
                    _window.Close();
                }
                if(player1 == player2)
                {
                    noNameLabel_2.Content = "Player 2 heeft dezelde naam als player 1";
                }
            
            }
            if (string.IsNullOrEmpty(naamSpeler2.Text))
            {
                noNameLabel_2.Content = "U heeft geen naam ingevuld!";
            }

        }

        public void Back(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new NaamInvoeren(_navigator, _window, _mainNav));
        }
       
    }
}
