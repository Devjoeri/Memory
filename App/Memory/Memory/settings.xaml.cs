﻿using System;
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
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        private INavigator _navigator;
        public string theme_Path = "themes/mlp";
        public settings(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        private void theme_Mlp(object sender, RoutedEventArgs e)
        {
            
        }

        private void theme_Fruit(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
