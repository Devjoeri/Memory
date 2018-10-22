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
    /// Interaction logic for Mainmenu.xaml
    /// </summary>
    public partial class Mainmenu : Page
    {
        private INavigator _navigator;
        public Mainmenu(INavigator navigator)
        {
            _navigator = navigator;
            InitializeComponent();
        }

        private void SinglePlayer(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Game(_navigator));
        }

        private void Highscores(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Highscores(_navigator));
        }

        private void exit_Game(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
