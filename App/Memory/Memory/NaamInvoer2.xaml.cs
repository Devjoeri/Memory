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
        private string player2;
        private int difficulty;
        INavigator _navigator;
        NaamInvoerenWindow _window;
        public NaamInvoer2(NaamInvoerenWindow window, INavigator navigator)
        {
            InitializeComponent();
            _window = window;
            _navigator = navigator;
        }

        public void Next(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(naamSpeler2.Text))
            {
                this.player2 = naamSpeler2.Text;
                //Ga terug naar main window
                _window.Close();
            }

        }

        public void Back(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new NaamInvoeren(_navigator, _window));
        }
    }
}
