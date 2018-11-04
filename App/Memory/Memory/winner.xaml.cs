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
    /// Hier de pop-up voor de winnaar, en de redirections voor de knoppen "Mainmenu"  en "Highscores"
    /// </summary>
    public partial class winner : Window
    {
        //string playerName = "Placeholder PlayerName";

        private INavigator _navigator;
        public winner(INavigator navigator, string playerName)
        {
            _navigator = navigator;
            InitializeComponent();

            this.LabelWinnaar.Content = "U heeft gewonnen " + playerName;
        }

        private void to_Mainmenu(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Mainmenu(_navigator));
        }

        private void to_Highscore(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Highscores(_navigator));
        }

        
    }
}
