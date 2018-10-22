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
    /// Interaction logic for winner.xaml
    /// </summary>
    public partial class winner : Page
    {
        private INavigator _navigator;
        public winner(INavigator navigator)
        {
            _navigator = navigator;
            InitializeComponent();
        }

        private void to_Mainmenu(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Mainmenu(_navigator));
        }

        private void to_Highscore(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Highscores(_navigator));
        }
    }
}