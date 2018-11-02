using System;
using System.Collections.Generic;
using System.IO;
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
    /// Hier kun je een ander thema kiezen
    /// Met behulp van een dropdown menu
    /// </summary>
    public partial class settings : Page
    {
        private int counter = 0;
        private INavigator _navigator;

        public settings(INavigator navigator)
        {
            _navigator = navigator;
            InitializeComponent();
            add_Options();
        }

        /// <summary>
        /// Add all folders to buttons, custom themes
        /// </summary>
        private void add_Options()
        {
            string[] folderArray = Directory.GetDirectories(".../.../testSettings");
            foreach(string folder in folderArray)
            {
                Button btn = new Button();
                btn.Width = 500;
                btn.Height = 25;
                btn.Content = folder;
                // btn.Click += new EventHandler();
                settings_Stackpanel.Children.Add(btn);
            }

        }
    }
}
