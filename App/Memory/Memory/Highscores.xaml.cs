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
using System.IO;

namespace Memory
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Page
    {
        private INavigator _navigator;
        public Highscores(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
            loadHighscore("Hallo");
        }

        private void terug_highscore(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Mainmenu(_navigator));
        }

        private void loadHighscore(string fileName)
        {

            try
            {

                String json = File.ReadAllText(new Uri("Images/" + fileName + ".txt", UriKind.Relative).ToString());
                Console.WriteLine(json);
            }
            catch (Exception e)
            {

            }
        }
    }
}
