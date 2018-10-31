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
    /// Interaction logic for NaamInvoeren.xaml
    /// </summary>
    public partial class NaamInvoeren : Page
    {
        private INavigator _navigator, _mainNav;
        private string player1;
        private int gridsize = 4;
        NaamInvoerenWindow _window;

        public NaamInvoeren(INavigator navigator, NaamInvoerenWindow window, INavigator mainNav)
        {
            InitializeComponent();
            _mainNav = mainNav;
            _navigator = navigator;
            _window = window;
        }

        public void Next(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text))
            {
                this.player1 = nameInput.Text;
                _navigator.Navigate(new NaamInvoer2(_window, _navigator, _mainNav, player1, gridsize));
            }
            
        }

    }
}
