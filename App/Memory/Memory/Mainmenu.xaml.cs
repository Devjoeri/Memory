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
    /// Alle main menu knoppen en events om door te navigeren naar een andere WPF page.
    /// </summary>
    public partial class Mainmenu : Page
    {
        private INavigator _navigator;
        public Mainmenu(INavigator navigator)
        {
            _navigator = navigator;
            InitializeComponent();
        }
        
        /// <summary>
        /// Starts singeplayer game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SinglePlayer(object sender, RoutedEventArgs e)
        {
            NaamInvoeren setupDialog = new NaamInvoeren();
            setupDialog.ShowDialog();
            _navigator.Navigate(new Game(_navigator));
        }
        
        /// <summary>
        /// Stuurt de gebruiker door naar de highscore page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscores(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Highscores(_navigator));
        }

        /// <summary>
        /// Exits het spel met exit code "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Game(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
