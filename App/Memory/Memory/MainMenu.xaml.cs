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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private INavigator _navigator;
        public MainMenu(INavigator navigator)
        {
            this._navigator = navigator;
            InitializeComponent();
        }
        private void SinglePlayerButton(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Game(_navigator));
        }
    }
}
