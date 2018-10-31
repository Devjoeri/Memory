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
        private INavigator _navigator;
        public NaamInvoeren(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
            
        }

        public void Next(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new NaamInvoer2());
        }
    }
}
