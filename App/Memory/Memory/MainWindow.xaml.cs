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
    /// Hier plaatsen we alle pages om te displaye.
    /// dit gebeurd allemaal in een frame.
    /// </summary>
    public partial class MainWindow : INavigator
    {
        
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Navigate(new Mainmenu(this));
        }

        public object FormWindowState { get; }

        public void Navigate(Page p)
        {
            MainFrame.Navigate(p);
        }
    }
}
