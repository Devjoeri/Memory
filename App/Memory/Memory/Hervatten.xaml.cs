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

namespace Memory
{
    /// <summary>
    /// Interaction logic for Hervatten.xaml
    /// </summary>
    public partial class Hervatten : Window
    {
        private INavigator _navigator;

        public Hervatten(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        public void jaHervatten(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Game(_navigator));
        }

        public void neeHervatten(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Game(_navigator));
        }

    }
}
